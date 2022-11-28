using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class WriterMessage
    {
        public int WriterMessageID { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Reciever { get; set; }
        public string RecieverName { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
