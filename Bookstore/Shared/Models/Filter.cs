using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models
{
    public class Filter
    {
        public ICollection<string> Genres { get; set; }
        public ICollection<string> Languages { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Boolean AvailableOnly { get; set; }
        public Boolean PartOfSeries { get; set; }
    }
}
