using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Proje.Areas.Customer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Security.Principal;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[controller]/[action]/")]
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());
        ServiceManager serviceManager = new ServiceManager(new EFServicesDal());

        private readonly UserManager<User> _userManager;

        public ProjectController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            Context c = new Context();

            ViewBag.Services = c.Services.Select(x=> new SelectListItem() { Text=x.Title, Value =x.ServiceID.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project p)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ProjectValidator validations = new ProjectValidator();

            Context c = new Context();

            Project newProject = new Project()
            {
                ClientUserID = Convert.ToInt32(userId),
                ProjectName = p.ProjectName,
                ServiceID = p.ServiceID,
                Description = p.Description,
                IsComfirmed = false,
                CreationDate = DateTime.Now
            };

            ValidationResult results = validations.Validate(newProject);

            if (results.IsValid)
            {
                projectManager.TAdd(newProject);

                return RedirectToAction("DashboardIndex", "CustomerDashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.Services = c.Services.Select(x => new SelectListItem() { Text = x.Title, Value = x.ServiceID.ToString() }).ToList();

            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> ProjectList()
        {

            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = projectManager.TGetListByFilter(userId);


            return View(values);
        }

         
        [HttpGet("{id}")]
        public  IActionResult ProjectDetails(int id)
        {
            ProjectDetailModel model = new ProjectDetailModel();

            var project =  projectManager.TGetById(id);
            var service = serviceManager.TGetById(project.ServiceID);
            
            
            model.ProjectID = project.ProjectID;
            model.ProjectName = project.ProjectName;
            model.ServiceType = service.Title;
            model.Description = project.Description;
            model.Progress = project.Progress;

            return View(model);
        }

        //Detayları modal'a yansıtma

        [HttpGet("{id}")]
        public IActionResult ProjecDetailsInModal(int id)
        {
            var project = projectManager.TGetById(id);
            return PartialView(project);
        }


        [HttpPost]
        public  IActionResult ProjecUpdateInModal(Project proje)
        {
            projectManager.TUpdate(proje);

            return RedirectToAction("ProjectList", "Project");
            
        }
    }
}
