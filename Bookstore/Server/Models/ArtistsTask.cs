using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class ArtistsTask
    {
        [Key]
        public int ArtistsTaskId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<ArtistsTaskTechnique> Techniques { get; set; }
    }
}
