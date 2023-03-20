using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        
        [Compare("Password", ErrorMessage = "Lütfen Şifrenizi doğru giriniz")]
        public string? ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Lütfen Email adresinizi Giriniz")]
        //public string? Email { get; set; }

        //[Required(ErrorMessage = "Lütfen resim Giriniz")]
        //public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen resim Giriniz")]
        public IFormFile? Picture { get; set; }

    }
}
