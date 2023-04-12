using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        MessageManager writerMessageManager = new MessageManager(new EFMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "admin@mail.com";
            var values = writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x=>x.MessageID).Take(3).ToList();
            return View(values);
        }
    }
}
