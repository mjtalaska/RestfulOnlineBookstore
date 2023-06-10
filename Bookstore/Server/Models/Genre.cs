using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class BookType
    {
        public int BookTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
