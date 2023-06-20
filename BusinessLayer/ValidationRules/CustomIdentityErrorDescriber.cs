using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit() 
            => new IdentityError { Code = "PasswordRequiresDigit", Description = "Şifre rakam içermelidir" };

        public override IdentityError PasswordTooShort(int length) 
            => new IdentityError { Code = "PasswordTooShort", Description = "Şifre en az altı karakter olmalıdır" };

        public override IdentityError PasswordRequiresUpper() 
            => new IdentityError { Code = "PasswordRequiresUpper", Description = "Şifre en az bir büyük harf içermelidir" };

        public override IdentityError PasswordRequiresLower()
            => new IdentityError { Code = "PasswordRequiresLower", Description = "Şifre en az bir küçük harf içermelidir" };
        

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifre ne az bir noktalama işareti içermelidir" };
        



    }
}
