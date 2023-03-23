using BusinessLayer.Concrete;
using Core_Proje.Models;
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

            EditServiceModel model = new EditServiceModel();
            model.ServiceID = value.ServiceID;
            model.Title = value.Title;

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceDetailsInModal(EditServiceModel p)
        {
            int id = p.ServiceID;
            var service = serviceManager.TGetById(id);

            if (p.ServiceIcon != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ServiceIcon.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Template/images/services/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ServiceIcon.CopyToAsync(stream);
                service.ImageUrl = imageName;
            }

            service.Title = p.Title;

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
