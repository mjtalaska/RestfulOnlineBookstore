using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IEnumerable<RetrieveBook>> GetBooks()
        {
            return await _service.GetBooks();
        }
    }
}
