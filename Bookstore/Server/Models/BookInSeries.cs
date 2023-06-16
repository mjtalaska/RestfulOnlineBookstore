using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual Book Book { get; set; }
        [Required]
        public virtual Series Series { get; set; }
    }
}
