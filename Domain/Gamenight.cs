using Domain.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gamenight
    {
        public int Id { get; set; }

        public int HostId { get; set; }
        public User Host { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<Participating> Participants { get; set; }

        public DateTime DateTime { get; set; }

        // Public List<Boardgame> BoardgameList { get; set; }
        // Public List<Food> FoodList { get; set; }


    }
}
