using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Core_Proje.Customer.Writer.Controllers
{
    [Area("Customer")]
    [Route("Customer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<User> _userManager;

        public MessageController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("RecieverMessage")]
        public async Task<IActionResult> RecieverMessage(string p)
        {
            //var value = await _userManager.FindByNameAsync(User.Identity.Name);

            ClaimsPrincipal currentUser = this.User;

            var id =  _userManager.GetUserId(currentUser);

            var value = await _userManager.FindByIdAsync(id);

            p = value.Email;

            var mesageList = writerMessageManager.GetListReceiverMessage(p);

            return View(mesageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            p = value.Email;

            var mesageList = writerMessageManager.GetListSenderMessage(p);

            return View(mesageList);
        }

        [Route("MessageDetails/{id}")]
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            Message writerMessage = writerMessageManager.TGetById(id);

            return View(writerMessage);

        }

        [Route("ReceiverMessageDetails/{id}")]
        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            Message writerMessage = writerMessageManager.TGetById(id);

            return View(writerMessage);

        }



        [Route("")]
        [Route("SendMessage")]
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();  
        }


        [Route("")]
        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string fullName = value.Name + " " + value.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderUserName = mail;
            p.SenderFullName = fullName;
            Context c = new Context();

            var userFullName = c.Users.Where(x => x.Email == p.RecieverUserName).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var admins = await _userManager.GetUsersInRoleAsync("Admin");

            p.RecieverFullName = admins.FirstOrDefault().Surname;
            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessage");
        }


        //Modal

        [Route("MessageDetailsInModal/{id}")]
        [HttpGet]
        public IActionResult MessageDetailsInModal(int id)
        {
            var message = writerMessageManager.TGetById(id);

            return PartialView(message);
        }


    }
}
