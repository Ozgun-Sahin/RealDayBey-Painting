using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class ClientUser :IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<WriterRole> WriterRoles { get; set; }
    }
}
