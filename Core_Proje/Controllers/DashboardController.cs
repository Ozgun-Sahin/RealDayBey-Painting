using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult DashboardIndex()
        {
            ProjectManager projectManager = new ProjectManager(new EFProjectDal());

            var thisMounthsProjects = projectManager.GetListProjectsByCreationDate();

            int totalIncome = 0;
            int totalOutcome = 0;

            foreach (var item in thisMounthsProjects)
            {
                totalIncome = (int)(totalIncome + item.Price);
                totalOutcome = (int)(totalOutcome + item.Expence);
            }

            ViewBag.totalIncome = totalIncome;
            ViewBag.totalOutcome = totalOutcome;
            ViewBag.net = totalIncome - totalOutcome;

            return View();
        }
    }
}
