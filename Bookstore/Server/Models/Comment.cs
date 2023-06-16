using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
