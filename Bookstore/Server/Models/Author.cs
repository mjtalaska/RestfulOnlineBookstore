using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Author : Person
    {
        public int AuthorId { get; set; }
        public string Pseudonym { get; set; }
        
        public virtual ICollection<AuthorBook> Books { get; set; }
    }
}
