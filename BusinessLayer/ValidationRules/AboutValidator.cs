using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator :AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş bırakılamaz");   
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotNull().WithMessage("Lütfen bir resim seçiniz"); 
        }
    }
}
