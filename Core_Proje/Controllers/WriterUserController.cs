using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EFWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(userManager.TGetList());
            
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(ClientUser p)
        {
            userManager.TAdd(p);
            var value = JsonConvert.SerializeObject(p);
            return Json(value);
        }
    }  
}
