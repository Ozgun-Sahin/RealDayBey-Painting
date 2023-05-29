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
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDal());

        [HttpGet]
        public IActionResult ContactSubplaceIndex()
        {
            var value = contactManager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult ContactSubplaceIndex(Contact contact)
        {
            ContactValidator validations = new ContactValidator();

            ValidationResult results = validations.Validate(contact);

            if (results.IsValid)
            {
                contactManager.TUpdate(contact);
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
