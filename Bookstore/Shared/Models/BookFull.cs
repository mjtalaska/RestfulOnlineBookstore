using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models
{
    public class BookFull : RetrieveBook
    {
        public int Year { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int? AdvisedAge { get; set; }
        public PublisherInfo Publisher { get; set; }
        public string Language { get; set; }
        public ICollection<string> Types { get; set; }
    }
}
