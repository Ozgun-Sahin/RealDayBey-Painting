using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly UserManager<User> _userManager;

        public DefaultController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            //MessageManager _messageManager = new MessageManager(new EFMessageDal());
            //p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //p.Status = true;
            //_messageManager.TAdd(p);
           

            MessageManager _writerMessageManager = new MessageManager(new EFMessageDal());

            var admin = await _userManager.GetUsersInRoleAsync("Admin");
            p.RecieverFullName = admin.FirstOrDefault().Name + " " + admin.FirstOrDefault().Surname;
            p.RecieverUserName = admin.FirstOrDefault().UserName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            _writerMessageManager.TAdd(p);

            return RedirectToAction("Index");
        }

    }
}
