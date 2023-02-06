using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int Progress { get; set; }
        public double Price { get; set; }
        public bool IsComfirmed { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public  ClientUser ClientUser { get; set; }
        public int ClientUserID { get; set; }
        public Service Service { get; set; }
        public int ServiceID { get; set; }

    }
}
