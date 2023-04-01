using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 :ViewComponent
    {
        Context c = new Context();

        private readonly UserManager<ClientUser> _userManager;

        public StatisticsDashboard2(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await _userManager.GetUsersInRoleAsync("Admin");

            string adminUserName = admin.FirstOrDefault().UserName;
            

            ViewBag.ConfirmedProjects = c.Projects.Where(x => x.IsComfirmed == true).Count();
            ViewBag.PendingProjects = c.Projects.Where(x => x.IsComfirmed == false).Count();
            ViewBag.RecievedMessages = c.WriterMessages.Where(x => x.RecieverUserName == adminUserName).Count();
            ViewBag.SentMessages = c.WriterMessages.Where(x => x.SenderUserName == adminUserName).Count();

            return View();  
        }
    }
}
