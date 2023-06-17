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
            var query2 = await _context.Books
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
            return query2;
        }

        public async Task<BookFull> GetFullBookInformation(int id)
        {
            var query = await _context.Books
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

            return query;
        }
    }
}
