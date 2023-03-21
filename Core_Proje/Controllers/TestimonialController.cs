using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager TestimonialManager = new TestimonialManager(new EFTestimonialDal());
        public IActionResult TestimonialIndex()
        {
            var values = TestimonialManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = TestimonialManager.TGetById(id);
            TestimonialManager.TDelete(value);
            return RedirectToAction("TestimonialIndex");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
           
            var value = TestimonialManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            TestimonialManager.TUpdate(testimonial);
            return RedirectToAction("TestimonialIndex");

        }

        //Modal
        [HttpGet]
        public IActionResult TestimonialDetailsInModal(int id)
        {
            var testimonial = TestimonialManager.TGetById(id);

            return PartialView(testimonial);
        }

        [HttpPost]
        public IActionResult TestimonialDetailsInModal(Testimonial testimonial)
        {
            TestimonialManager.TUpdate(testimonial);

            return RedirectToAction("TestimonialIndex");
        }

    }
}
