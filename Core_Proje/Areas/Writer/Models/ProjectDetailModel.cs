using EntitiyLayer.Concrete;
using NuGet.Protocol.Plugins;

namespace Core_Proje.Areas.Writer.Models
{
    public class ProjectDetailModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }

    }
}
