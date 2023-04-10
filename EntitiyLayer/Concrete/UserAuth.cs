using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class UserAuth :IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
        public virtual User CustomerUser { get; set; }
    }
}
