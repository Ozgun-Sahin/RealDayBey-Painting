using BusinessLayer.Concrete;
using Core_Proje.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDal());
        public IActionResult SocialMediaIndex()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            socialMediaManager.TAdd(p);
            return RedirectToAction("SocialMediaIndex");
        }

        [HttpGet("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(value);
            return RedirectToAction("SocialMediaIndex");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var value = socialMediaManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        //Modal
        [HttpGet("{id}")]
        public IActionResult EditSocialMediaInModal(int id)
        {
            var value = socialMediaManager.TGetById(id);
            return PartialView(value);
        }

        [HttpPost("{id}")]
        public IActionResult EditSocialMediaInModal(SocialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("SocialMediaIndex");
        }

        [HttpGet]
        public IActionResult AddSocialMediaInModal()
        {
            string[] icons = { "fab fa-github", "fab fa-linkedin", "fab fa-facebook", "fab fa-instagram" };

            List<string> ikonlar = new List<string>() { "fab fa-github", "fab fa-linkedin", "fab fa-facebook", "fab fa-instagram" };

            SelectListItem ikonlar2 = new SelectListItem() { Text = "face", Value =1.ToString() };

            ViewBag.Icons = ikonlar2;

            return PartialView();
        }

        [HttpPost]
        public IActionResult AddSocialMediaInModal(AddSocialMediaModel p)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Name = p.Name,
                Icon = p.Icon,
                Url = p.Url
            };

            socialMediaManager.TAdd(socialMedia);

            return RedirectToAction("SocialMediaIndex");
        }

    }
}
