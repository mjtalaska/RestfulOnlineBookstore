using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        
        [Required]
        public virtual Book Book { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
