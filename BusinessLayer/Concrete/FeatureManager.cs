using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public Feature TGetById(int id)
        {
            return _featureDal.GetByID(id);
        }

        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
           _featureDal.Delete(t);
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);
        }

        public List<Feature> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetListByFilter(int p)
        {
            throw new NotImplementedException();
        }
    }
}
