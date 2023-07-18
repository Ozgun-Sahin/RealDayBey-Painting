using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public List<Project> GetListCompletedProjectWithUserDatas()
        {
            Context c = new Context();

            List<Project> projects = c.Projects.Where(x => x.IsComfirmed == true && x.Progress == 100).Include(x => x.ClientUser).ToList();

            return (projects);
        }

        public List<Project> GetListPendingProject()
        {
            return _projectDal.GetByFilter(x => x.IsComfirmed == false);
        }

        public List<Project> GetListProjectsByCreationDate()
        {
            return _projectDal.GetList().Where(x => x.CreationDate.Month == DateTime.Now.Month).ToList();
        }

        public List<Project> GetListShowCaseProjects()
        {
            return _projectDal.GetByFilter(x => x.Showcase == true);
        }

        public List<Project> GetListWithUserDatas()
        {
            //throw new NotImplementedException();

            Context c = new Context();

            List<Project> projects = c.Projects.Include(x => x.ClientUser).ToList();

            return(projects);
        }

        public List<Project> GetListWorkInProgressProject()
        {
            return _projectDal.GetByFilter(x => x.IsComfirmed == true && x.Progress <= 99);
        }

        public Project GetProjectByIdWithUserDatas(int id)
        {
            Context c = new Context();

            Project project = c.Projects.Where(x => x.ProjectID == id).Include(x => x.ClientUser).FirstOrDefault();

            return project;
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
            return _projectDal.GetByFilter(x => x.ClientUserID == p).ToList();
        }

        public void TUpdate(Project t)
        {
            _projectDal.Update(t);
        }
    }
}
