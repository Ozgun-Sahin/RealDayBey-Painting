using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {

        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());

        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]

        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.TGetById(id);

            experienceManager.TDelete(value);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi";
            var value = experienceManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");

        }

    }
}
