namespace Core_Proje.Areas.Admin.Models
{
    public class AboutEditModel
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
