﻿using Microsoft.AspNetCore.Mvc;
using Bookstore.Server.Services;
using Bookstore.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Shared.Models;

namespace Bookstore.Server.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly IBooksService _service;
        public BooksController( IBooksService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IEnumerable<RetrieveBook>> GetBooksByFilter(Filter filter)
        {
            return await _service.GetBooksByFilter(filter);
        }

        [HttpGet("/details/{id}")]
        public async Task<BookFull> GetFullBookInfo(string id)
        {
            return await _service.GetFullBookInformation(int.Parse(id));
        }

        [HttpPost("/cart/{userName}")]
        public async Task<IActionResult> AddBookToBasket(string userName, RetrieveBook book)
        {
            int bookId = book.BookId;
            string response = "Not ok, something doesn't work again";
            var result = await _service.AddBookToBasket(bookId, userName);
            switch (result)
            {
                case 1: response = $"Added {book.Title} to cart"; break;
                case 2: response = $"Increased the amount of {book.Title} in cart"; break;
                case -1: response = $"The name {userName} is incorrect"; break;
            }
            return Ok(response);
        }

        [HttpGet("/cart/{userName}")]
        public async Task<IEnumerable<BookInCart>> GetBooksFromUsersCart(string userName)
        {
            return await _service.GetBooksInCart(userName);
        }

        [HttpPost("/cart/change/{userName}")]
        public async Task<IActionResult> ChangeCart(string userName, BookInCart[] booksInCart)
        {
            var result = await _service.SaveCartChanges(userName, booksInCart);
            return Ok(result);
        }

        [HttpGet("/filters/{text}")]
        public async Task<Filter> GetAvailableFilters(string text)
        {
            return await _service.GetAvailableFilters(text);
        }

        [HttpGet("/checkout/{userName}")]
        public async Task<decimal> GetFinalPrice(string userName)
        {
            return await _service.GetFinalPrice(userName);
        }

        [HttpPost("/checkout/{userName}")]
        public async Task<IActionResult> PurchaseBooksInCart(string userName, decimal final)
        {
            var result = await _service.Purchase(userName);
            string message = "";
            switch (result)
            {
                case -1: message = "Nothing was purchased - your cart is empty"; break;
                case 0: message = "Succesfully finalized the transaction"; break;
            }
            return Ok(message);
        }
    }
}
