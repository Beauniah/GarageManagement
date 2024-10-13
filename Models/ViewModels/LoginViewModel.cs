using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name Required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string? Password { get; set; }
        [Display(Name = "Remeber Me")]
        public bool RememberMe { get; set; }
    }
}
