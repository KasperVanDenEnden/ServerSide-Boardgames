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

        public User Host { get; set; }

        public Address Address { get; set; }

        public List<User> Participants { get; set; }

        public DateTime DateTime { get; set; }

        // Public List<Boardgame> BoardgameList { get; set; }
        // Public List<Food> FoodList { get; set; }


    }
}
