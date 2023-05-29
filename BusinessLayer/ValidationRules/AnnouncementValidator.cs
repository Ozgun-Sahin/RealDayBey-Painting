using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen bir içerik yazınız");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bir konu başlığı yazınız");
        }
    }
}
