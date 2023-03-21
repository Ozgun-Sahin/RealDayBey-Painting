using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
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
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("DashboardIndex", "Dashboard");

        }
    }
}
