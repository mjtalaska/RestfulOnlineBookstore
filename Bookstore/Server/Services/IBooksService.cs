﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Server.Models;
using Bookstore.Shared.Models;

namespace Bookstore.Server.Services
{
    public interface IBooksService
    {
        public Task<IEnumerable<RetrieveBook>> GetBooksByFilter(Filter filter);
        public Task<Filter> GetAvailableFilters(string search);
        public Task<BookFull> GetFullBookInformation(int id);
        public Task<int> AddBookToBasket(int bookId, string userName);
        public Task<IEnumerable<BookInCart>> GetBooksInCart(string userName);
        public Task<int> SaveCartChanges(string userName, BookInCart[] booksInCart);
        public Task<decimal> GetFinalPrice(string userName);
        public Task<int> Purchase(string userName);
    }
}
