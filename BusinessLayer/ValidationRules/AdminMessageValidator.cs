﻿using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AdminMessageValidator : AbstractValidator<Message>
    {
        public AdminMessageValidator()
        {
            RuleFor(x => x.RecieverFullName).NotNull().WithMessage("Böyle bir kullanıcı bulunamadı");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
        }
    }
}