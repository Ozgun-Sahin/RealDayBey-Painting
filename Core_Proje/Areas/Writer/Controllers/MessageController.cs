using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> RecieverMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            p = value.Email;

            var mesageList = writerMessageManager.GetListReceiverMessage(p);

            return View(mesageList);
        }

        public async Task<IActionResult> SenderMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            p = value.Email;

            var mesageList = writerMessageManager.GetListSenderMessage(p);

            return View(mesageList);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);

            return View(writerMessage);

        }

        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);

            return View(writerMessage);

        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string name = value.Name + " " + value.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;

            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessage" ,"Message");
        }
    }
}
