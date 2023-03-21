using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_Proje.Controllers
{
    public class AdminMessageBoxController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<ClientUser> _userManager;

        public AdminMessageBoxController(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            ClaimsPrincipal currentUser = this.User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListReceiverMessage(userName);

            return View(messageList);
        }

        public async Task<IActionResult> Outbox()
        {
            ClaimsPrincipal currentUser = this.User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListSenderMessage(userName);

            return View(messageList);
        }



        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            ClaimsPrincipal Admin = this.User;
            var admin = await _userManager.GetUserAsync(Admin);
            var user = _userManager.Users.Where(x => x.UserName == p.RecieverUserName).FirstOrDefault();

            p.SenderFullName = admin.Name + " " + admin.Surname;
            p.RecieverFullName = user.Name + " " + user.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderUserName = admin.UserName;


            writerMessageManager.TAdd(p);

            return RedirectToAction("DashboardIndex", "Dashboard");
        }


        //Modal
        [HttpGet]
        public IActionResult MessageDetailsInModal(int id)
        {
            var message = writerMessageManager.TGetById(id);

            return PartialView(message);
        }



    }
}
