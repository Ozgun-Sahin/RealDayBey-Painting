﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Project> GetListCompletedProject()
        {
            return _projectDal.GetByFilter(x => x.IsComfirmed == true && x.Progress == 100);
        }

        public List<Project> GetListPendingProject()
        {
            return _projectDal.GetByFilter(x => x.IsComfirmed == false);
        }

        public List<Project> GetListWorkInProgressProject()
        {
            return _projectDal.GetByFilter(x => x.IsComfirmed == true && x.Progress <= 99);
        }

        public void TAdd(Project t)
        {
           _projectDal.Insert(t);
        }

        public void TDelete(Project t)
        {
            _projectDal.Delete(t);
        }

        public Project TGetById(int id)
        {
            return _projectDal.GetByID(id);
        }

        public List<Project> TGetList()
        {
            return _projectDal.GetList();
        }

        public List<Project> TGetListByFilter(int p)
        {
            //throw new NotImplementedException();

            return _projectDal.GetByFilter(x => x.ClientUserID == p).ToList();
        }

        public void TUpdate(Project t)
        {
            _projectDal.Update(t);
        }
    }
}
