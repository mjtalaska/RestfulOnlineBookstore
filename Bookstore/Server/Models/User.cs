using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Cart> InCart { get; set; }
    }
}
