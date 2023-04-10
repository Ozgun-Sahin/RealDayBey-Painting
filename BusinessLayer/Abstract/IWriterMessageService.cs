using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService: IGenericServices<Message>
    {
        List<Message> GetListSenderMessage(string p);
        List<Message> GetListReceiverMessage(string p);
    }
}
