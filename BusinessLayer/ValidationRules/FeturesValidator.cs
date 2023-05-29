using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class FeturesValidator :AbstractValidator<Feature>
    {
        public FeturesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Header).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
