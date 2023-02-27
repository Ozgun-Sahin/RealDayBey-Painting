using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());

        public IActionResult Index()
        {
            var values = projectManager.TGetList();

            return View(values);
        }

        public IActionResult DeleteProject(int id)
        {
            var value = projectManager.TGetById(id);
            projectManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProject(int id)
        {
            var value = projectManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            projectManager.TUpdate(project);
            return RedirectToAction("Index");
        }


    }
}
