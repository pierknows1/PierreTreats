using System.ComponentModel.DataAnnotations;

namespace PierreTreats.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(nameof = "Email or Username")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}