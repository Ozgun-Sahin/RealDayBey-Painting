using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ProjectList :ViewComponent
    {
        
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());

        public IViewComponentResult Invoke()
        {
            var values = projectManager.TGetList();
            return View(values);
        }


    }
}
