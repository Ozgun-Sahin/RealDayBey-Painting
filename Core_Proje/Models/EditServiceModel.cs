namespace Core_Proje.Models
{
    public class EditServiceModel
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public IFormFile? ServiceIcon { get; set; }

    }
}
