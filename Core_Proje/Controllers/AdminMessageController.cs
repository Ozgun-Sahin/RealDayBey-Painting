using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());
        public IActionResult ReceieverMessageList()
        {
            TempData["DeleteUrl"] = "ReceieverMessageList";
            string p = "admin@mail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            TempData["DeleteUrl"] = "SenderMessageList";
            string p = "admin@mail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetail(int id)
        {
            var value = writerMessageManager.TGetById(id);
            return View(value);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            string viewUrl = TempData["DeleteUrl"].ToString();
            var value = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(value);
            return RedirectToAction(viewUrl);
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }


        //Burası bir revize edilecek
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.SenderUserName = "admin@mail.com";
            p.SenderFullName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var recieverFullName = c.Users.Where(x => x.UserName == p.RecieverUserName).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.RecieverFullName = recieverFullName;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }

    }
}
