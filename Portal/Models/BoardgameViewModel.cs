using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class BoardgameViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public EGenre Genre { get; set; }
        [Required]
        public bool IsPG18 { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public EGametype Gametype { get; set; }
    }
}
