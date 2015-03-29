using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_UoW.Model.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            CreatedOn = DateTime.Now;
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }


        public string LastModifiedById { get; set; }
        [ForeignKey("LastModifiedById")]
        public virtual ApplicationUser LastModifiedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string ApprovedById { get; set; }
        [ForeignKey("ApprovedById")]
        public virtual ApplicationUser ApprovedBy { get; set; }

        public bool? Activated { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
