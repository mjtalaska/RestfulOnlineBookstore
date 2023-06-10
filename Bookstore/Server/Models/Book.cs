using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Bookstore.Server.Models
{
    public enum Genre
    {
        ScienceFiction,
        Thriller,
        Fantasy,
        Detective
    }

    public enum Status
    {
        Available, 
        Unavailable
    }

    public enum BookType
    {
        Book,
        ForKids,
        Comic
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public CultureInfo OriginalLanguage { get; set; }
        public int Amount { get; set; }
        public string Cover { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public Status Status { get; set; }
        public int AdvisedAge { get; set; }
        public ICollection<BookType> Type { get; set; }

        public virtual ICollection<AuthorBook> Authors { get; set; }
    }
}
