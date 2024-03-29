﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public Service TGetById(int id)
        {
            return _serviceDal.GetByID(id); 
        }

        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public List<Service> TGetList()
        {
           return _serviceDal.GetList();
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);
        }

        public List<Service> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<Service> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<Service> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }
    }
}
