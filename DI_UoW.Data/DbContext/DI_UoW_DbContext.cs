using DI_UoW.Model.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DI_UoW.Data.DbContext
{
    public class DI_UoW_DbContext: IdentityDbContext<ApplicationUser>
    {
        public DI_UoW_DbContext()
            : base("DI_UoW_DbContext")
        {
            Database.SetInitializer<DI_UoW_DbContext>(new CreateDatabaseIfNotExists<DI_UoW_DbContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
