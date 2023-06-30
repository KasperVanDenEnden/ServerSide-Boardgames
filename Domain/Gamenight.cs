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
        public bool IsPG18 { get; set; }

        // many-to-many
        [Required]
        public List<GamenightBoardgame> Boardgames { get; set; }

        // public List<Food> FoodList { get; set; }

        // Extra attributes beyond requirements
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        // One of the chosen boardgames image
        [Required]
        public byte[] Image { get; set; }
    }
}
