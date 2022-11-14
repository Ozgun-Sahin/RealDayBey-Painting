using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class UserMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
