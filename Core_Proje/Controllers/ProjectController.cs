using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());

        public IActionResult ProjectIndex()
        {
            var values = projectManager.TGetList();

            return View(values);
        }

        public IActionResult Portfolio()
        {
            var values = projectManager.GetListCompletedProject();

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

            EditProjectViewModel model = new EditProjectViewModel();
            model.ProjectID = value.ProjectID;
            model.ProjectName = value.ProjectName;
            model.Price = value.Price;
            model.Progress = value.Progress;
            model.Expence = value.Expence;
            model.ProjectImageURL = value.ProjectImage;
           


            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditProject(EditProjectViewModel p)
        {
            int id = p.ProjectID;

            var project = projectManager.TGetById(id);

            if (p.ProjectImage !=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ProjectImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/projectImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ProjectImage.CopyToAsync(stream);
                project.ProjectImage = imageName;
            }

            project.Progress = p.Progress;
            project.Price = p.Price;
            project.Expence = p.Expence;
            project.CompletionDate = DateTime.Now;
            project.IsComfirmed = p.IsComfirmed;
            //project.IsComfirmed = true;
            
            projectManager.TUpdate(project);

            return RedirectToAction("ProjectIndex", "Project");
        }

        //Modal

        [HttpGet]
        public IActionResult ProjectDetailsInModal(int id)
        {
            var value = projectManager.TGetById(id);

            EditProjectViewModel model = new EditProjectViewModel();
            model.ProjectID = value.ProjectID;
            model.ProjectName = value.ProjectName;
            model.Price = value.Price;
            model.Progress = value.Progress;
            model.Expence = value.Expence;
            model.ProjectImageURL = value.ProjectImage;



            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectDetailsInModal(EditProjectViewModel p)
        {
            int id = p.ProjectID;

            var project = projectManager.TGetById(id);

            if (p.ProjectImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ProjectImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/projectImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ProjectImage.CopyToAsync(stream);
                project.ProjectImage = imageName;
            }

            project.Progress = p.Progress;
            project.Price = p.Price;
            project.Expence = p.Expence;
            project.CompletionDate = DateTime.Now;
            project.IsComfirmed = p.IsComfirmed;
            //project.IsComfirmed = true;

            projectManager.TUpdate(project);

            return RedirectToAction("ProjectIndex");
        }

    }
}
