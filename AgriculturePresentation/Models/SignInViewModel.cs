using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
        
    }
}
