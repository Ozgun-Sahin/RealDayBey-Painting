using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        
        public void TAdd(Project t)
        {
           _projectDal.Insert(t);
        }

        public void TDelete(Project t)
        {
            throw new NotImplementedException();
        }

        public Project TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Project> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Project t)
        {
            throw new NotImplementedException();
        }
    }
}
