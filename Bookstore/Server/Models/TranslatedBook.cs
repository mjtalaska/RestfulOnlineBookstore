using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class TranslatedBook
    {
        [Key]
        public int TranslatedBookId { get; set; }

        [Required]
        public int BookId { get; set; }
        [Required]
        public int TranslatorId { get; set; }
        [Required]
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Book Book { get; set; }
        public virtual Translator Translator { get; set; }
    }
}
