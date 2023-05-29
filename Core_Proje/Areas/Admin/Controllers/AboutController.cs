using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Proje.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Data;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDal());

        [HttpGet]
        public IActionResult AboutIndex()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Düzenleme";
            var value = aboutManager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> AboutIndex(AboutEditModel p)
        {
            int id = p.AboutID;
            var about = aboutManager.TGetById(id);

            if (p.ImageUrl !=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Template/images/about/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ImageUrl.CopyToAsync(stream);
                about.ImageUrl = imageName;
            }



            AboutValidator validations = new AboutValidator();

            ValidationResult results = validations.Validate(about);

            if (results.IsValid)
            {
                aboutManager.TUpdate(about);
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
