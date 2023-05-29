using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Admin.Models
{
    public class AddSocialMediaModel
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bir URL giriniz")]
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
