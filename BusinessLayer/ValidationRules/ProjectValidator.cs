using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen bir açıklama yazınız");
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Lütfen bir başlık yazınız");
            
        }
    }
}
