using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Consumable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDrink { get; set; }
        public bool IsVegan { get; set; }
        public bool NonAlcoholic { get; set; }
        public bool NoLactose { get; set; }
        public bool NoNuts { get; set; }



    }
}
