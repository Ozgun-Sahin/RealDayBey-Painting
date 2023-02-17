using BusinessLayer.Concrete;
using Core_Proje.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]/")]
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());
        ServiceManager serviceManager = new ServiceManager(new EFServicesDal());

        private readonly UserManager<ClientUser> _userManager;

        public ProjectController(UserManager<ClientUser> userManager)
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
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            int clientUserId = value.Id;

            Project newProject = new Project()
            {
                ClientUserID = clientUserId,
                ProjectName = p.ProjectName,
                ServiceID = p.ServiceID,
                Description = p.Description,
                IsComfirmed = true
            };

            projectManager.TAdd(newProject);

            return RedirectToAction("DashboardIndex", "WriterDashboard");
        }

        [HttpGet]
        public IActionResult ProjectList()
        {
            var values = projectManager.TGetList();
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

        //Modal denemeleri

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
