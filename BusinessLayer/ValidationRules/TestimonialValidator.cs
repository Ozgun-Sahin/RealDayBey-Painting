using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class TestimonialValidator :AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bir konu başlığı giriniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
