using Domain.Enums;
using Domain.Many_To_Many;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Boardgame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public EGenre Genre { get; set; }
        [Required]
        public bool IsPG18 { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public EGametype Gametype { get; set; }

        // many-to-many
        public List<GamenightBoardgame> GamenightBoardgames { get; set; }
    }
}
