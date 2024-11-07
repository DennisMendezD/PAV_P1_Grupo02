using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace PAV_P1_Grupo02.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        [IntegerValidator(MinValue = 19)]
        public int Edad { get; set; }

        [Required]
        public string Puesto { get; set; }

        [Required]
        [Display(Name = "Tarjeta de crédito")]
        public string TarjetaCredito { get; set; }

        [Required]
        [Display(Name = "País")]
        [StringLength(50,ErrorMessage = "Sólo se permiten textos mayores o iguales a 3 caracteres y menores a 50 caracteres", MinimumLength = 3)]
        public string Pais { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Sólo se permiten textos mayores o iguales a 3 caracteres y menores a 50 caracteres", MinimumLength = 3)]
        public string Provincia { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Sólo se permiten textos mayores o iguales a 3 caracteres y menores a 50 caracteres", MinimumLength = 3)]
        public string Distrito { get; set; }

        [Required]
        [Display(Name = "Cantón")]
        [StringLength(50, ErrorMessage = "Sólo se permiten textos mayores o iguales a 3 caracteres y menores a 50 caracteres", MinimumLength = 3)]
        public string Canton { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Sólo se permiten textos mayores o iguales a 3 caracteres y menores a 50 caracteres", MinimumLength = 3)]
        public string Detalle { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
