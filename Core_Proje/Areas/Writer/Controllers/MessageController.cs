using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<ClientUser> _userManager;

        public MessageController(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("RecieverMessage")]
        public async Task<IActionResult> RecieverMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

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
            WriterMessage writerMessage = writerMessageManager.TGetById(id);

            return View(writerMessage);

        }

        [Route("ReceiverMessageDetails/{id}")]
        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);

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
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string fullName = value.Name + " " + value.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = fullName;
            Context c = new Context();

            var userFullName = c.Users.Where(x => x.Email == p.Reciever).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var admins = await _userManager.GetUsersInRoleAsync("Admin");

            p.RecieverName = admins.FirstOrDefault().Surname;
            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessage");
        }


        //Modal Denemeleri

        [Route("MessageDetailsInModal/{id}")]
        [HttpGet]
        public IActionResult MessageDetailsInModal(int id)
        {
            var message = writerMessageManager.TGetById(id);

            return PartialView(message);
        }


    }
}
