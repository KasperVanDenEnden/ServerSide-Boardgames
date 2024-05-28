using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username or email")]
        [Display(Name = "Username/Email")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
