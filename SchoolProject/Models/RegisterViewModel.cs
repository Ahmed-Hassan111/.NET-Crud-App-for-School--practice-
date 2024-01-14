using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5,ErrorMessage = "Minimum Password length is 5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }



    }
}
