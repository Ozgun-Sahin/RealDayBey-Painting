using BusinessLayer.Concrete;
using Core_Proje.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());

        public IActionResult ProjectIndex()
        {
            //var values = projectManager.TGetList();

            var values2 = projectManager.GetListWithUserDatas();

            return View(values2);
        }

        public IActionResult Portfolio()
        {
            //var values = projectManager.GetListCompletedProject();

            var values = projectManager.GetListCompletedProjectWithUserDatas();

            return View(values);
        }

        [HttpGet("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var value = projectManager.TGetById(id);
            projectManager.TDelete(value);
            return RedirectToAction("ProjectIndex", "Project");
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
            project.Description = p.Description;
            //project.IsComfirmed = true;

            projectManager.TUpdate(project);

            return RedirectToAction("ProjectIndex", "Project");
        }

        //Modal

        //[HttpGet]
        [HttpGet("{id}")]
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
            model.IsComfirmed = value.IsComfirmed;
            model.Showcase = value.Showcase;
            model.Description = value.Description;

            return PartialView(model);
        }

        [HttpPost("{id}")]
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
            project.Showcase = p.Showcase;
            project.Description = p.Description;
            //project.IsComfirmed = true;

            projectManager.TUpdate(project);

            return RedirectToAction("ProjectIndex");
        }

    }
}
