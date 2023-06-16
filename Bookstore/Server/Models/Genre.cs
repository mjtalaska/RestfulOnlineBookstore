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

        public virtual ICollection<BookGenre> Books { get; set; }
    }

    public class BookGenre
    {
        [Key]
        public int BookGenreId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int GenreId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
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

        public virtual ICollection<BookBookType> Books { get; set; }
    }

    public class BookBookType
    {
        [Key]
        public int BookBookTypeId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int BookTypeId { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookType BookType { get; set; }
    }

    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<TranslatedBook> Translations { get; set; }
        public virtual ICollection<TranslatorLanguage> Translators { get; set; }
    }

    public class TranslatorLanguage
    {
        [Key]
        public int TranslatorLanguageId { get; set; }
        [Required]
        public int TranslatorId { get; set; }
        [Required]
        public int LanguageId { get; set; }

        public virtual Translator Translator { get; set; }
        public virtual Language Language { get; set; }
    }

    public class Technique
    {
        [Key]
        public int TechniqueId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ArtistTechnique> Artists { get; set; }
        public virtual ICollection<ArtistsTaskTechnique> ArtistsTasks { get; set; }
    }

    public class ArtistTechnique
    {
        [Key]
        public int ArtistTechniqueId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int TechniqueId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Technique Technique { get; set; } 
    }

    public class ArtistsTaskTechnique
    {
        [Key]
        public int ArtistTechnique { get; set; }
        [Required]
        public int ArtistTaskId { get; set; }
        [Required]
        public int TechniqueId { get; set; }
 
        public virtual ArtistsTask ArtistsTask { get; set; }
        public virtual Technique Technique { get; set; }
    }
}
