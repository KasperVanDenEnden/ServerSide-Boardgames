using Domain;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class GamenightViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Date must be in the future.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.Time)]
        [AfterTime(ErrorMessage = "Time must be after 6pm.")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "At least one board game must be selected.")]
        public List<int> SelectedBoardgameIds { get; set; }

        [Required]
        public bool IsPG18 { get; set; }

        // Address
        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "House number is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "House number should be numeric.")]
        [NotZero(ErrorMessage = "House number cannot be 0.")]
        public int Housenumber { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{4}\s?[a-zA-Z]{2}$", ErrorMessage = "Postal code should be in the format '1234 AB'.")]
        public string Postal { get; set; }
    }

}


