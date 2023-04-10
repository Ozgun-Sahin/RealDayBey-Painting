using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        public List<Message> GetListReceiverMessage(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.RecieverUserName == p);
        }

        public List<Message> GetListSenderMessage(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.SenderUserName == p);
        }

        public void TAdd(Message t)
        {
            _writerMessageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _writerMessageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _writerMessageDal.GetByID(id);
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
