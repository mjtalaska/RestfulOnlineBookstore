using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Series
    {
        [Key]
        public int SeriesId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookInSeries> Books { get; set; }
    }
}
