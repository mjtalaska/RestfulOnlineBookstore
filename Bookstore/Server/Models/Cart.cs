using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int Amount { get; set; }
        
        [Required]
        public virtual Book Book { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
