using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IMessageService: IGenericServices<Message>
    {
        List<Message> GetListSenderMessage(string p);
        List<Message> GetListReceiverMessage(string p);
    }
}
