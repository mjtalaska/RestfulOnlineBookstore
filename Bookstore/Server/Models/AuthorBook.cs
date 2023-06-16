using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class AuthorBook
    {
        [Key]
        public int AuthorBookId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BookId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
