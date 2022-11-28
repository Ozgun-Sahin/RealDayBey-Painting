using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Notification :ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var value = announcementManager.TGetList().Take(5).ToList();
            return View(value);
        }
    }
}
