using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Customer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string? Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string? Password { get; set; }
    }
}
