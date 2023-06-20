namespace Core_Proje.Areas.Admin.Models
{
    public class EditProjectViewModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int Progress { get; set; }
        public double Price { get; set; }
        public double Expence { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool IsComfirmed { get; set; }
        public bool Showcase { get; set; }
        public string ProjectImageURL { get; set; }
        public IFormFile? ProjectImage { get; set; }
        public string Description { get; set; }
}
}
