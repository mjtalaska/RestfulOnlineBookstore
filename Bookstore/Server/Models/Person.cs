using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Server.Models
{
    public abstract class Person
    {
        [Key]
        public int PersonId { get; set;  }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirht { get; set; }
    }
}
