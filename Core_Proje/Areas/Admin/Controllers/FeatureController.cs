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
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

        [HttpGet]
        public IActionResult FeatureIndex()
        {
            var value = featureManager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult FeatureIndex(Feature feature)
        {
            FeturesValidator validations = new FeturesValidator();

            ValidationResult results = validations.Validate(feature);

            if (results.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("DashboardIndex", "Dashboard");
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
    }
}
