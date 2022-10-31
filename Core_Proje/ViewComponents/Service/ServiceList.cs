using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EFServicesDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
    }
}
