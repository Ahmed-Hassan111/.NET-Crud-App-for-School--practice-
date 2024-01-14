using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Minimum Password length is 5")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
