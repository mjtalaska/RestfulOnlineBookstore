using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Server.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Amount { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string Cover { get; set; }
        [Range(0,200)]
        public int? AdvisedAge { get; set; }

        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int LanguageId { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Status Status { get; set; }
        public virtual Language Language { get; set; }
        public virtual TranslatedBook TranslatedBook { get; set; }
        public virtual BookInSeries BookInSeries { get; set; }

        [MaxLength(3)]
        public virtual ICollection<AuthorBook> Authors { get; set; }
        public virtual ICollection<ArtistsTask> ComicArtists { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<BookBookType> Type { get; set; }
        public virtual ICollection<BookGenre> Genres { get; set; }
    }
}
