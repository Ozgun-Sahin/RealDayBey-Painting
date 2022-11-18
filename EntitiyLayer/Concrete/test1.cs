using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class test1
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
