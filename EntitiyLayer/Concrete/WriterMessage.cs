using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class WriterMessage
    {
        public int WriterMessageID { get; set; }
        public string SenderUserName { get; set; }
        public string SenderFullName { get; set; }
        public string RecieverUserName { get; set; }
        public string RecieverFullName { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
