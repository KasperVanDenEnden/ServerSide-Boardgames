using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class ReviewViewModel
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
    }
}
