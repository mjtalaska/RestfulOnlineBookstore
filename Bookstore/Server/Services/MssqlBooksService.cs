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
            var books = await (from b in _context.Books
                               join ab in _context.AuthorsBooks on b.BookId equals ab.BookId
                               join a in _context.Authors on ab.AuthorId equals a.PersonId
                               select new RetrieveBook{ Title = b.Title, Status = b.Status.Name, Cover = b.Cover, Year = b.Year, Authors = (a.Name + " " + a.Surname) })
                               .ToArrayAsync();
            var query = books.GroupBy(g => new { Title = g.Title, Status = g.Status, Cover = g.Cover, Year = g.Year })
                .Select(b => new RetrieveBook { Title = b.Key.Title, Status = b.Key.Status, Cover = b.Key.Cover, Year = b.Key.Year, Authors = string.Join(",", b.Select(i => i.Authors)) }).ToArray();
            return query;
        }
    }
}
