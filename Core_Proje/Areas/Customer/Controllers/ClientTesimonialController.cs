using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/ClientTesimonial")]
    public class ClientTesimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());


        private readonly UserManager<User> _userManager;

        public ClientTesimonialController(UserManager<User> userManager)
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
            TestimonialValidator validations = new TestimonialValidator();

            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            string fullName = value.Name + " " + value.Surname;

            p.ClientName = fullName;
            p.ImageUrl = "/userimage/" + value.ImageUrl;

            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                testimonialManager.TAdd(p);

                return RedirectToAction("DashboardIndex", "CustomerDashboard");
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
