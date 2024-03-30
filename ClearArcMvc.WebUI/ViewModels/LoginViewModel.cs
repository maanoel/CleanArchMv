using System.ComponentModel.DataAnnotations;

namespace ClearArcMvc.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Email is REquired")]
        [EmailAddress(ErrorMessage = "Invlaid Format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} ad max {1} characters long", 
            MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
