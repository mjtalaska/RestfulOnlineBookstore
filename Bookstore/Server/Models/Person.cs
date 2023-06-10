using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Bookstore.Server.Models
{
    public abstract class Person
    {
        public int PersonId { get; set;  }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirht { get; set; }
    }
}
