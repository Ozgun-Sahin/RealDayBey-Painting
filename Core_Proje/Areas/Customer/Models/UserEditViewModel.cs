using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Customer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]

        [Compare("Password", ErrorMessage = "Lütfen Şifrenizi doğru giriniz")]
        public string? PasswordConfirm { get; set; }
        public string? PictureUrl { get; set; }
        public IFormFile? Picture { get; set; }

    }
}
