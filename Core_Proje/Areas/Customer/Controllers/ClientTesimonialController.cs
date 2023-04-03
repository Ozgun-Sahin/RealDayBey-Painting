using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/ClientTesimonial")]
    public class ClientTesimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());


        private readonly UserManager<ClientUser> _userManager;

        public ClientTesimonialController(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("AddTestimony")]
        [HttpGet]
        public IActionResult AddTestimony()
        {
            return View();
        }


        [Route("")]
        [Route("AddTestimony")]
        [HttpPost]
        public async Task<IActionResult> AddTestimony(Testimonial p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            string fullName = value.Name + " " + value.Surname;

            p.ClientName = fullName;
            p.ImageUrl = "/userimage/" + value.ImageUrl;

            testimonialManager.TAdd(p);

            return RedirectToAction("DashboardIndex", "WriterDashboard");
        }


    }
}
