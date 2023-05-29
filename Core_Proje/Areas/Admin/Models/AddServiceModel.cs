using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Admin.Models
{
    public class AddServiceModel
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık Giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Seçiniz")]
        public IFormFile? ServiceIcon { get; set; }
    }
}
