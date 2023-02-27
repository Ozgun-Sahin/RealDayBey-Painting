using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactServices
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetByID(id);
        }

        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);  
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }

        public List<Contact> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }
    }
}
