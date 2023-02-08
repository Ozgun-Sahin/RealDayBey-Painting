using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class WriterRole :IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
        public virtual ClientUser ClientUser { get; set; }
    }
}
