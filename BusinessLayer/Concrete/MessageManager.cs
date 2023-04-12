using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListReceiverMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.RecieverUserName == p);
        }

        public List<Message> GetListSenderMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.SenderUserName == p);
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
