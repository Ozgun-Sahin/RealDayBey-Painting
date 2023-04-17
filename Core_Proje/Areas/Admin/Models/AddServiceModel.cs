namespace Core_Proje.Areas.Admin.Models
{
    public class AddServiceModel
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public IFormFile? ServiceIcon { get; set; }
    }
}
