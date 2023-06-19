using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class BookInSeries
    {
        [Key]
        public int BookInSeriesId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int SeriesId { get; set; }
        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Series Series { get; set; }

        public Boolean IsInSeries(Book book)
        {
            return Book.Equals(book);
        }
    }
}
