using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string? Confirmpassword { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

    }
}
