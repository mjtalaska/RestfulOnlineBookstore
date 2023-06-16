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
        public int TranslatedId { get; set; }

        public virtual Language TranslatedLanguage { get; set; }
        [Required]
        public virtual Book Book { get; set; }
        
        public virtual Translator Translator { get; set; }
    }
}
