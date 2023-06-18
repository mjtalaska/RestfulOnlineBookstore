using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models
{
    public class BookInCart
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string? Series { get; set; }
        public int? Number { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public decimal Price { get; set; }
    }
}
