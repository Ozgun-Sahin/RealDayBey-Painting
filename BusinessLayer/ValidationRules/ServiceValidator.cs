using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.ImageUrl).NotNull();

        }
    }
}
