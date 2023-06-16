using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Artist : Person
    {
        public virtual ICollection<Technique> KnownTechniques { get; set; }
        public virtual ICollection<ArtistsTask> Tasks { get; set; }
    }
}
