using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class BookType
    {
        [Key]
        public int BookTypeId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<TranslatedBook> Translations { get; set; }
        public virtual ICollection <Translator> Translators { get; set; }
    }

    public class Technique
    {
        [Key]
        public int TechniqueId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}
