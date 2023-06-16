using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Range(1,10)]
        [Required]
        public int Score { get; set; }
        public string? Review { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual Book Book { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
