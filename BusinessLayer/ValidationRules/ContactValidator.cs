using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bir başlık giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen bir açıklama yazınız");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen bir e-mail giriniz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lütfen bir telefon numarası giriniz");
        }
    }
}
