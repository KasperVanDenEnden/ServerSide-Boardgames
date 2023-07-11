using Domain;

namespace Portal.Models
{
    public class GamenightDetailViewModel
    {
        public Gamenight Gamenight { get; set; }
        public ReviewViewModel Review { get; set; } = new ReviewViewModel();
    }
}
