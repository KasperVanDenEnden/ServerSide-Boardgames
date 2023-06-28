using Domain.Many_To_Many;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gamenight
    {
        public int Id { get; set; }


        [Required]
        public int HostId { get; set; }
        public User Host { get; set; }

        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<Participating> Participants { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public List<Boardgame> BoardgameList { get; set; }
        // public List<Food> FoodList { get; set; }


    }
}
