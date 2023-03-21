﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        TestimonialManager testimonialMaganer = new TestimonialManager(new EFTestimonialDal());

        public IViewComponentResult Invoke()
        {
            var values = testimonialMaganer.GetListConfirmedTestimonials().OrderByDescending(x => x.TestimonialID).ToList();

            return View(values);
        }
    }
}
