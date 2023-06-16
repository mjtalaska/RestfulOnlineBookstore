using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Author : Person
    {
        public string? Pseudonym { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
