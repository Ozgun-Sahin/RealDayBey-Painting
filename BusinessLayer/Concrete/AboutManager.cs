using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutServices
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);    
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public List<About> TGetList()
        {
           return _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }

        public List<About> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<About> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }
    }
}
