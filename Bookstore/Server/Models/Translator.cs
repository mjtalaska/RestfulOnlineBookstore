using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Translator : Person
    {
        public virtual ICollection<Language> KnownLanguages { get; set; }
        public virtual ICollection<TranslatedBook> Books { get; set; }
    }
}
