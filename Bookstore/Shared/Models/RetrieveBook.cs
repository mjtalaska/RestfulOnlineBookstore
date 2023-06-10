using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models
{
    public class RetrieveBook
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public string Cover { get; set; }
        public string Authors { get; set; }
    }
}
