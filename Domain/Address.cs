using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        public int Id { get; set; } 
        public string Street { get; set; }
        public int Housenumber { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
    }
}
