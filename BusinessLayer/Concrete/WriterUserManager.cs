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

        public void TAdd(User t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public User TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> TGetList()
        {
            return _writerUserDal.GetList();
        }

        public List<User> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<User> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User t)
        {
            throw new NotImplementedException();
        }
    }
}
