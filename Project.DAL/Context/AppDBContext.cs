using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models.Concrete;

namespace Project.DAL.Context
{
    public class AppDBContext: IdentityDbContext<AppUser,AppRole,int>
    {
        public AppDBContext()
        {
            
        }

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<DepartmentCompany> DepartmentCompany { get; set; }
		public DbSet<Leave> Leaves { get; set; }
        public DbSet<Advance> Advances { get; set; }
        public DbSet<Expense> Expenses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            IdentityUserRole<int> userRole = new IdentityUserRole<int>();
            userRole.UserId = 1;
            userRole.RoleId = 1;
            builder.Entity<IdentityUserRole<int>>().HasData(userRole);

            IdentityUserRole<int> userRole2 = new IdentityUserRole<int>();
            userRole2.UserId = 2;
            userRole2.RoleId = 2;
            builder.Entity<IdentityUserRole<int>>().HasData(userRole2);

            IdentityUserRole<int> userRole3 = new IdentityUserRole<int>();
            userRole3.UserId = 3;
            userRole3.RoleId = 3;
            builder.Entity<IdentityUserRole<int>>().HasData(userRole3);

            IdentityUserRole<int> userRole4 = new IdentityUserRole<int>();
            userRole4.UserId = 4;
            userRole4.RoleId = 3;
            builder.Entity<IdentityUserRole<int>>().HasData(userRole4);

            IdentityUserRole<int> userRole5 = new IdentityUserRole<int>();
            userRole5.UserId = 5;
            userRole5.RoleId = 3;
            builder.Entity<IdentityUserRole<int>>().HasData(userRole5);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data source=.;Initial catalog=BADE_DB;Integrated security=true;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=tcp:badehr.database.windows.net,1433;Initial Catalog=BADE_DB;Persist Security Info=False;User ID=adminuser;Password=Admin_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		}
	}
}
