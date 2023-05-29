using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
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
            AnnouncementValidator validations = new AnnouncementValidator();

            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                announcementManager.TAdd(p);

                return RedirectToAction("AdminAnnouncementIndex");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();

        }

        [HttpGet("{id}")]
        public IActionResult AnnouncementDetailsInModal(int id)
        {
            var value = announcementManager.TGetById(id);

            return PartialView(value);
        }

    }
}
