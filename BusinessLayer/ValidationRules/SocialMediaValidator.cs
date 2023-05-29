using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidator:AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Icon).NotNull();
            RuleFor(x => x.Url).NotEmpty().WithMessage("Lütfen bir URL giriniz");
        }
    }
}
