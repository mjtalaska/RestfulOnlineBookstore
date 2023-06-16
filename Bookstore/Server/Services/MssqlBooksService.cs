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
                    Year = e.Year, 
                    Authors = string.Join(" ", 
                    e.Authors.Select(s => s.Name + " " + s.Surname)),
                    Genres = e.Genres.Select(s => s.Name).ToArray()
                })
                .ToArrayAsync();
            return query2;
        }
    }
}
