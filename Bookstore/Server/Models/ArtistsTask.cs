using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class ArtistsTask
    {
        public int ArtistsTaskId { get; set; }
        
        public virtual Book Comic { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Technique> Techniques { get; set; }
    }
}
