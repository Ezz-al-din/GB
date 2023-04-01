using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is FirstName")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "User Name is LastName")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }
    
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
