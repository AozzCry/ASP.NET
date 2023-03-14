using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
        public Role() { }
        public Role(string name, RoleValue roleValue) : base(name)
        {
            RoleValue = roleValue;
        }
    }
}
