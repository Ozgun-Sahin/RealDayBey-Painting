﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    public class TestimonialController : Controller
    {
        TestimonialManager TestimonialManager = new TestimonialManager(new EFTestimonialDal());
        public IActionResult TestimonialIndex()
        {
            var values = TestimonialManager.TGetList();
            return View(values);
        }

        [HttpGet("{id}")]
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
        [HttpGet("{id}")]
        public IActionResult TestimonialDetailsInModal(int id)
        {
            var testimonial = TestimonialManager.TGetById(id);

            return PartialView(testimonial);
        }

        [HttpPost("{id}")]
        public IActionResult TestimonialDetailsInModal(Testimonial testimonial)
        {
            TestimonialManager.TUpdate(testimonial);

            return RedirectToAction("TestimonialIndex");
        }

    }
}