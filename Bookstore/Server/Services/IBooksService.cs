using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Server.Models;
using Bookstore.Shared.Models;

namespace Bookstore.Server.Services
{
    public interface IBooksService
    {
        public Task<IEnumerable<RetrieveBook>> GetBooks();
        public Task<BookFull> GetFullBookInformation(int id);
    }
}
