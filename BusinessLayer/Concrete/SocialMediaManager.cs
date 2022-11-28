using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public List<SocialMedia> TGetList()
        {
           return _socialMediaDal.GetList();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }

        public List<SocialMedia> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }
    }
}
