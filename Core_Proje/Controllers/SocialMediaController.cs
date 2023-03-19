using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Controllers
{
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
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
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
        [HttpGet]
        public IActionResult EditSocialMediaInModal(int id)
        {
            var value = socialMediaManager.TGetById(id);
            return PartialView(value);
        }

        [HttpPost]
        public IActionResult EditSocialMediaInModal(SocialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("SocialMediaIndex");
        }


    }
}
