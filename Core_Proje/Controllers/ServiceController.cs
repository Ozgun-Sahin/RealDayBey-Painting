using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServicesDal());
        public IActionResult ServiceIndex()
        {
            var value = serviceManager.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("ServiceIndex");
        }

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetById(id);

            serviceManager.TDelete(value);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var value = serviceManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");

        }

        //Modal
        [HttpGet]
        public IActionResult ServiceDetailsInModal(int id)
        {
            var value = serviceManager.TGetById(id);
            return PartialView(value);
        }

        [HttpPost]
        public IActionResult ServiceDetailsInModal(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("ServiceIndex");
        }

        [HttpGet]
        public IActionResult AddServiceInModal()
        {
            return PartialView();
        }


        [HttpPost]
        public IActionResult AddServiceInModal(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("ServiceIndex");
        }

    }
}
