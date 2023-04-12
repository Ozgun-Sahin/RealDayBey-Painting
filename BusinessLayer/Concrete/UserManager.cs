using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class UserManager :IUserService
    {
        IUserDal _UserDal;
        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
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
            return _UserDal.GetList();
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
