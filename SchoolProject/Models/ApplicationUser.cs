using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAgree { get; set; }
    }
}
