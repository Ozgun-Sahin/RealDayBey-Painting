using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class AdminAnnouncementController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());

        public IActionResult AdminAnnouncementIndex()
        {
            var values = announcementManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public IActionResult MakeAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnnouncement(Announcement p)
        {
            announcementManager.TAdd(p);

            return RedirectToAction("AdminAnnouncementIndex");
        }

        //Modal
        [HttpGet]
        public IActionResult MakeAnnouncementInModal()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> MakeAnnouncementInModal(Announcement p)
        {
            announcementManager.TAdd(p);

            return RedirectToAction("AdminAnnouncementIndex");
        }

        [HttpGet("{id}")]
        public IActionResult AnnouncementDetailsInModal(int id)
        {
            var value = announcementManager.TGetById(id);

            return PartialView(value);
        }

    }
}
