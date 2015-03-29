using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_UoW.Model.Entities
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name, string description)
            : base(name)
        {

            this.Description = description;

        }

        public virtual string Description { get; set; }

    }
}
