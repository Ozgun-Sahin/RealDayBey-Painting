using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[controller]/[action]/")]
    public class CustomerDashboardController : Controller
    {
        private readonly UserManager<User> _userManager;

        public CustomerDashboardController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> DashboardIndex()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            

            ViewBag.v = value.Name + " "+ value.Surname;

            //Weather API

            string apikey = "da0f36b2a77fbd727ca163a09d1c00fd";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&units=metric&appid=" + apikey;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //burası çok gereksiz
            Context c = new Context();

            ViewBag.v1 = c.Projects.Where(x => x.ClientUserID == value.Id && x.Progress < 100).Count();
            ViewBag.v2 = c.Projects.Where(x => x.ClientUserID == value.Id && x.Progress == 100).Count();
            ViewBag.v3 = c.Messages.Where(x => x.SenderUserName == value.UserName).Count();
            ViewBag.v4 = c.Messages.Where(x => x.RecieverUserName == value.UserName).Count();
            ViewBag.v6 = c.Announcements.ToList();

            return View();
        }
    }
}

/*
 https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&units=metric&appid=da0f36b2a77fbd727ca163a09d1c00fd
 */
