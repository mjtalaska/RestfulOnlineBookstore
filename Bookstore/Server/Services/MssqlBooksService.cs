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

        //Returns all the books in extent in a simpler form
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

        //Returns a list of books matching the requested filters.
        public async Task<IEnumerable<RetrieveBook>> GetBooksByFilter(Filter filter)
        {
            //find id's of genres selected by the client
            List<int> genres;
            if(filter.Genres.Count != 0)
            {
                genres = await _context.Genres.Where(e => filter.Genres.Contains(e.Name)).Select(e => e.GenreId).ToListAsync();
            }
            else
            {
                genres = await _context.Genres.Select(e => e.GenreId).ToListAsync();
            }
            //find id's of selected languages
            List<int> languages;
            if (filter.Languages.Count != 0)
            {
                languages = await _context.Languages.Where(e => filter.Languages.Contains(e.Name)).Select(e => e.LanguageId).ToListAsync();
            }
            else
            {
                languages = await _context.Languages.Select(e => e.LanguageId).ToListAsync();
            }
            //find books matching the filters, with PartOfSeries and AvailableOnly being optional selections
            var filteredBooks = await _context.Books.Where(e => 
            ((filter.PartOfSeries)? e.BookInSeries != null : true) &&
            ((filter.AvailableOnly)? e.StatusId == 1 : true) &&
            e.Price >= filter.MinPrice &&
            e.Price <= filter.MaxPrice &&
            e.Genres.Select(s => s.GenreId).Any(s => genres.Contains(s)) &&
            languages.Contains(e.LanguageId))
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

            return filteredBooks;
        }

        //returns more information about a book defined by the id
        public async Task<BookFull> GetFullBookInformation(int id)
        {
            var book = await _context.Books
                .Where(e => e.BookId == id)
                .Select(e => 
                new BookFull
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

        //Creats new Cart object in extent using information about the book's id and user's name
        public async Task<int> AddBookToBasket(int bookId, string userName)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                //get user's id based on the provided name
                var userId =  await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();
                //find Cart association between the specified user and book, if there is no such association a null will be returned
                var isInBasket = await _context.Carts.Where(e => e.BookId == bookId && e.UserId.Equals(userId)).FirstOrDefaultAsync();
                //select Status of a provided book
                var status = await _context.Books.Where(e => e.BookId == bookId).Select(e => e.Status.Name).FirstAsync();

                //unavailable books can't be added to cart
                if (status.Equals("Unavailable"))
                {
                    await transaction.RollbackAsync();
                    return -1;
                }

                //there is no Cart association between user and book, it needs to be created
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
                //there is a Cart association already, so we change it accordingly instead of creating a new one
                else
                {
                    var book = await _context.Books.Where(e => e.BookId == bookId).FirstAsync();
                    isInBasket.Amount = book.AmountOrMaxAvailable(isInBasket.Amount + 1);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return 2;
                }
            }
        }

        //Returns the list of books currently in chosen user's cart
        public async Task<IEnumerable<BookInCart>> GetBooksInCart(string userName)
        {
            //get user's id based on the name
            var userId = await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();
            //get information about all the books inside the user's cart
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

        //Updates the content of chosen user's cart based on the changes made by him and saved in booksInCart list
        public async Task<int> SaveCartChanges(string userName, BookInCart[] booksInCart)
        {
            //get user'id based on the name provided
            var userId = await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();

            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                //get all the books in users cart
                var pastBooksInCart = await _context.Carts.Where(e => e.UserId.Equals(userId)).ToListAsync();
                //each book is modified based on the contents of the according bookInCart object
                pastBooksInCart.Join(booksInCart, e => e.BookId, k => k.BookId, (e,k) => new { Cart = e, BookInCart = k})
                    .ToList()
                    .ForEach(e => e.Cart.Amount = e.BookInCart.Amount);
                //delete all the Cart associations where the value of amount is 0
                var booksToDelete = pastBooksInCart.Where(e => e.Amount == 0).ToList();
                _context.RemoveRange(booksToDelete);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return 1;
            }
        }

        //Returns default values for filters, as well as all of the possible filter choices
        public async Task<Filter> GetAvailableFilters(string text)
        {
            //get all the book instances
            var books = await _context.Books
                .ToArrayAsync();
            //get all the genre names in extent
            var genres = await _context.Genres.Select(e => e.Name).ToArrayAsync();
            //get all the language names in extent
            var languages = await _context.Languages.Select(e => e.Name).ToArrayAsync();

            //create Filters object, with all the available genres, languages, max and min prices and two flags - AvailableOnly and PartOfSeries
            Filter filter = new Filter
            {
                Genres = genres,
                Languages = languages,
                MaxPrice = books.Select(e => e.Price).Max(),
                MinPrice = books.Select(e => e.Price).Min(),
                AvailableOnly = false,
                PartOfSeries = false
            };

            return filter;
        }

        //Returns final cost of the contents of user's cart, including a 10% discount for all books belonging to a series if the cart contains the entire series
        public async Task<decimal> GetFinalPrice(string userName)
        {
            //get user's id based on user'name
            var userId = await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();
            //get all the Cart associations for the user
            var books = await _context.Carts.Where(e => e.UserId.Equals(userId)).ToListAsync();
            //get all the series present in user's cart, together with the number of books in the full series
            var fullSeries = await _context.BooksInSeries.Where(e => books.Select(e => e.BookId).Contains(e.BookId))
                .Join(_context.Series, e => e.SeriesId, k => k.SeriesId, (e, k) => new { SeriesId = e.SeriesId, FullSeriesAmount = k.Books.Count })
                .Distinct()
                .ToListAsync();
            List<Cart> booksInSeries = new List<Cart>();
            //find all the books belonging to a series in user's cart, and save their BookId and SeriesId for later evaluation
            var possibleSeries = books.Join(_context.BooksInSeries, e => e.BookId, k => k.BookId, (e, k) => new { BookId = e.BookId, SeriesId = k.SeriesId }).ToArray();
            foreach (var series in fullSeries)
            {
                //find all the books in user's cart belonging to the currently searched series
                var possible = possibleSeries.Where(e => e.SeriesId == series.SeriesId);
                //if the amount of books belonging to the searched series is the same as the number of books making up the whole series, add them to a booksInSeries list
                if (series.FullSeriesAmount == possible.Count())
                {
                    var booksToAdd = books.Where(e => possible.Select(s => s.BookId).Contains(e.BookId)).ToList();
                    booksInSeries.AddRange(booksToAdd);
                }
            }
            decimal sum = 0;
            //calculate the cost of series in cart, adding a 10% discount
            booksInSeries.Join(_context.Books, e => e.BookId, k => k.BookId, (e, k) => new { Price = k.Price, Amount = e.Amount }).ToList().ForEach(e => sum += e.Price * e.Amount * 0.9M);
            //calculate the cost of the rest of the books in cart, without the discount
            books.Except(booksInSeries).Join(_context.Books, e => e.BookId, k => k.BookId, (e,k) => new { Price = k.Price, Amount = e.Amount}).ToList().ForEach(e => sum += e.Price * e.Amount);

            //return the decimal with two spaces after the comma
            return decimal.Round(sum, 2, MidpointRounding.AwayFromZero);
        }

        //Creates new Purchase association between user and book based on the content of user's cart. Afterwards, the cart is emptied
        public async Task<int> Purchase(string userName)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                //get user id based on user name
                var userId = await _context.Users.Where(e => e.UserName.Equals(userName)).Select(e => e.Id).FirstAsync();
                //get a new object made from a Cart with a corresponding book for all the Cart objects associated with the specified user
                var cart = await _context.Carts.Where(e => e.UserId.Equals(userId)).Join(_context.Books, e => e.BookId, k => k.BookId, (e,k) => new { Book = k, Cart = e}).ToListAsync();
                List<Purchase> purchases = new List<Purchase>();
                //for each book in cart create new Purchase object and update the amount of available books
                cart.ForEach(e =>
                {
                    for (int i = 0; i < e.Cart.Amount; i++)
                    {
                        purchases.Add(new Purchase
                        {
                            BookId = e.Cart.BookId,
                            UserId = e.Cart.UserId,
                            PurchaseDate = DateTime.Now
                        });

                        e.Book.UpadateAmount(-1);
                    }
                });
                //updete the status of all the books - if amount <= 0, the state changes from Available to Unavailable
                await _context.Books.ForEachAsync(e => e.updateStatus());
                //add new Purchase objects to extent
                await _context.AddRangeAsync(purchases);
                //remove all the Cart associations for this user
                _context.Carts.RemoveRange(cart.Select(e => e.Cart).ToList());
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            return 0;
        }

    }
}
