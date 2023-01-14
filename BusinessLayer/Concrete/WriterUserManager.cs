using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class WriterUserManager :IWriterUserService
    {
        IWriterUserDal _writerUserDal;
        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public void TAdd(ClientUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ClientUser t)
        {
            throw new NotImplementedException();
        }

        public ClientUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientUser> TGetList()
        {
            return _writerUserDal.GetList();
        }

        public List<ClientUser> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ClientUser t)
        {
            throw new NotImplementedException();
        }
    }
}
