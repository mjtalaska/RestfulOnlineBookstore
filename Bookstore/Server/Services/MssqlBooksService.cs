using Bookstore.Server.Data;
using Bookstore.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Shared.Models;

namespace Bookstore.Server.Services
{
    public class MssqlBooksService : IBooksService
    {
        private readonly ApplicationDbContext _context;

        public MssqlBooksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RetrieveBook>> GetBooks()
        {
            var books = await _context.Books
                .Select(e => 
                new RetrieveBook 
                { 
                    BookId = e.BookId,
                    Title = e.Title, 
                    Status = e.Status.Name, 
                    Cover = e.Cover, 
                    Authors = e.Authors.Select(a => a.Author.Name + " " + a.Author.Surname).ToArray(),
                    Genres = e.Genres.Select(s => s.Genre).Select(s => s.Name).ToArray(),
                    Series = e.BookInSeries.Series.Name,
                    Number = e.BookInSeries.Number
                })
                .ToArrayAsync();
            return books;
        }

        public async Task<BookFull> GetFullBookInformation(int id)
        {
            var book = await _context.Books
                .Where(e => e.BookId == id)
                .Select(e => new BookFull
                { 
                    BookId = e.BookId,
                    Title = e.Title,
                    Status = e.Status.Name,
                    Year = e.Year,
                    Cover = e.Cover,
                    Authors = e.Authors.Select(a => a.Author.Name + " " + a.Author.Surname).ToArray(),
                    Series = e.BookInSeries.Series.Name,
                    Number = e.BookInSeries.Number,
                    Price = e.Price,
                    Amount = e.Amount,
                    AdvisedAge = e.AdvisedAge,
                    Language = e.Language.Name,
                    Publisher = new PublisherInfo { Name = e.Publisher.Name, WebAddress = e.Publisher.WebAddress},
                    Types = e.Type.Select(e => e.BookType.Name).ToArray(),
                    Genres = e.Genres.Select(e => e.Genre.Name).ToArray()
                })
                .FirstAsync();

            return book;
        }

        public async Task<int> AddBookToBasket(int bookId, string userName)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                var userId =  _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).First();
                var isInBasket = await _context.Carts.Where(e => e.BookId == bookId && e.UserId.Equals(userId)).FirstOrDefaultAsync();
                var status = await _context.Books.Where(e => e.BookId == bookId).Select(e => e.Status.Name).FirstAsync();

                if (status.Equals("Unavailable"))
                {
                    await transaction.RollbackAsync();
                    return -1;
                }

                if (isInBasket == null)
                {
                    await _context.Carts.AddAsync(new Cart
                    {
                        BookId = bookId,
                        UserId = userId,
                        Amount = 1
                    });
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return 1;
                }
                else
                {
                    var book = await _context.Books.Where(e => e.BookId == bookId).FirstAsync();
                    isInBasket.Amount = book.amountOrMaxAvailable(isInBasket.Amount + 1);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return 2;
                }
            }
        }

        public async Task<IEnumerable<BookInCart>> GetBooksInCart(string userName)
        {
            var userId = await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();
            var usersCart = await _context.Carts.Where(e => e.UserId.Equals(userId)).Select(e => new BookInCart
            {
                BookId = e.BookId,
                Title = e.Book.Title,
                Series = e.Book.BookInSeries.Series.Name,
                Number = e.Book.BookInSeries.Number,
                Price = e.Book.Price,
                Amount = e.Amount,
                Cover = e.Book.Cover,
                MaxAmount = e.Book.Amount
            }).ToArrayAsync();
            return usersCart;
        }

        public async Task<int> SaveCartChanges(string userName, BookInCart[] booksInCart)
        {
            var userId = _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).First();

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                var pastBooksInCart = await _context.Carts.Where(e => e.UserId.Equals(userId)).ToListAsync();
                pastBooksInCart.ForEach(e => e.Amount = booksInCart.Where(s => s.BookId == e.BookId).First().Amount);
                var booksToDelete = pastBooksInCart.Where(e => e.Amount == 0).ToList();
                _context.RemoveRange(booksToDelete);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return 1;
            }
        }

        public async Task<Filters> GetAvailableFilters(string text)
        {
            var books = await _context.Books
                .ToArrayAsync();
            var genres = await _context.Genres.Select(e => e.Name).ToArrayAsync();
            var languages = await _context.Languages.Select(e => e.Name).ToArrayAsync();

            Filters filters = new Filters
            {
                Genres = genres,
                Languages = languages,
                MaxPrice = books.Select(e => e.Price).Max(),
                MinPrice = books.Select(e => e.Price).Min(),
                AvailableOnly = false,
                PartOfSeries = false
            };

            return filters;
        }

    }
}
