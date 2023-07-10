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
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Yeni Şifrenizi Giriniz")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Yeni Şifrenizi Giriniz")]

        [Compare("NewPassword", ErrorMessage = "Lütfen Şifrenizi doğru giriniz")]
        public string? NewPasswordConfirm { get; set; }
        public string? PictureUrl { get; set; }
        public IFormFile? Picture { get; set; }

    }
}
