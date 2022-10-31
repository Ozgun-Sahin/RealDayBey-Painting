using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfoiloDal _portfolioDal;
        public PortfolioManager(IPortfoiloDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public Portfolio GetById(int id)
        {
           return _portfolioDal.GetByID(id);
        }

        public void TAdd(Portfolio t)
        {
            _portfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioDal.Delete(t);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDal.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioDal.Update(t);
        }
    }
}
