using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
