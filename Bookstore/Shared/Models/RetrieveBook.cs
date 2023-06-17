using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models
{
    public class RetrieveBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Cover { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Genres { get; set; }
        public int? Number { get; set; }
        public string? Series { get; set; }

        public Boolean isAvailable()
        {
            return Status.Equals("Available");
        }
    }
}
