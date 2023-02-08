using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<WriterRole> WriterRoles { get; set; }
    }
}
