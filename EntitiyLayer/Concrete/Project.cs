using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int Progress { get; set; }
        public double Price { get; set; }
        public bool IsComfirmed { get; set; }
        public string Comment { get; set; }

    }
}
