using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProjectController : Controller
    {
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());

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
        public IActionResult PendingProjectList()
        {
            var values = projectManager.GetListPendingProject();
            return View(values);
        }

        [HttpGet]
        public IActionResult WorkInProgressProjectList()
        {
            var values = projectManager.GetListWorkInProgressProject();
            return View(values);
        }

        [HttpGet]
        public IActionResult CompletedProjectList()
        {
            var values = projectManager.GetListCompletedProject();
            return View(values);
        }


    }
}
