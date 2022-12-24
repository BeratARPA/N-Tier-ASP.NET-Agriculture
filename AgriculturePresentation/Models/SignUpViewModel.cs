using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Posta boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifre aynı olmalıdır!")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş geçilemez!")]
        public string PhoneNumber { get; set; }
    }
}
