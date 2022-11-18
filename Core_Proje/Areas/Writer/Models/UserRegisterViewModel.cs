using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        
        [Compare("Password", ErrorMessage = "Lütfen Şifrenizi doğru giriniz")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Email adresinizi Giriniz")]
        public string Email { get; set; }
    }
}
