using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Proje.Areas.Admin.Models;
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
            ServiceValidator validations = new ServiceValidator();

            ValidationResult results = validations.Validate(service);

            if (results.IsValid)
            {
                serviceManager.TAdd(service);
                return RedirectToAction("ServiceIndex");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

            
        }

        [HttpGet("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetById(id);

            serviceManager.TDelete(value);

            return RedirectToAction("ServiceIndex","Service");
            
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
        [HttpGet("{id}")]
        public IActionResult ServiceDetailsInModal(int id)
        {
            var value = serviceManager.TGetById(id);

            EditServiceModel model = new EditServiceModel();
            model.ServiceID = value.ServiceID;
            model.Title = value.Title;

            return PartialView(model);
        }

        [HttpPost("{id}")]
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


            ServiceValidator validations = new ServiceValidator();

            ValidationResult results = validations.Validate(service);

            if (results.IsValid)
            {
                serviceManager.TUpdate(service);
                return RedirectToAction("ServiceIndex");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult AddServiceInModal()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddServiceInModal (AddServiceModel p)
        {
            Service service = new Service()
            {
                Title = p.Title,
            };

            if (p.ServiceIcon !=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ServiceIcon.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Template/images/services/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.ServiceIcon.CopyToAsync(stream);
                service.ImageUrl = imageName;
            }

            ServiceValidator validations = new ServiceValidator();

            ValidationResult results = validations.Validate(service);

            if (results.IsValid)
            {
                serviceManager.TAdd(service);
                return RedirectToAction("ServiceIndex");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            }

            return View();

        }

    }
}
