using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Many_To_Many
{
    public class Consumables
    {
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }


        public int GamenightId { get; set; }
        public Gamenight Gamenight { get; set; }


    }
}
