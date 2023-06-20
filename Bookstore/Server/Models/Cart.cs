using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Cart
    {
        public int BookId { get; set; }
        public string UserId { get; set; }
        [Required]
        public int Amount { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
