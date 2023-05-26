using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class CustomerMessageValidator :AbstractValidator<Message>
    {
        public CustomerMessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
        }
    }
}
