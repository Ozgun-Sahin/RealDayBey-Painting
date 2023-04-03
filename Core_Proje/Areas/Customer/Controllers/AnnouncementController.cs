using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    [Route("Customer/[controller]/[action]/")]

    public class AnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());

        public IActionResult AnnouncementIndex()
        {
            var values = announcementManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement = announcementManager.TGetById(id);

            return View(announcement);

        }

        [HttpGet("{id}")]
        public IActionResult AnnouncementDetailsInModal(int id)
        {
            Announcement announcement = announcementManager.TGetById(id);

            return PartialView(announcement);
        }



    }
}
