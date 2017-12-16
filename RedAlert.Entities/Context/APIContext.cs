using RedAlert.Entities.Models;
using RedAlert.Entities.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Entities.Context
{
    public class APIContext : DbContext
    {
        static APIContext()
        {
            Database.SetInitializer<APIContext>(null);
        }

        public APIContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }


        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInfo> ActivityInfoes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Compliance> Compliances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ActivityMap());
            modelBuilder.Configurations.Add(new ActivityInfoMap());
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new ComplianceMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
