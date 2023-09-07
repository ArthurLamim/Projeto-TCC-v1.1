using System.ComponentModel.DataAnnotations;

namespace AluguelToten.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {0} e no máximo {0} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
        public string? ConfirmPassword { get; set; }

        public string nomeUsuario { get; set; } = string.Empty;
        public string CPFUsuario { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
    }
}
