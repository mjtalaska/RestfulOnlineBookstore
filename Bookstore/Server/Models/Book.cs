using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Bookstore.Server.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public string Cover { get; set; }
        public int? AdvisedAge { get; set; }

        public virtual Status Status { get; set; }
        public virtual Language OriginalLanguage { get; set; }
        public virtual ICollection<BookType> Type { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<AuthorBook> Authors { get; set; }
        public virtual Translator Translator { get; set; }
    }
}
