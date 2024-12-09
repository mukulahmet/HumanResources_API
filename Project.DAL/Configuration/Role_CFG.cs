using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models.Concrete;

namespace Project.DAL.Configuration
{
    public class Role_CFG : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole {Id=1, Name="Admin",NormalizedName="ADMIN",ConcurrencyStamp=Guid.NewGuid().ToString() },

                new AppRole { Id = 2, Name = "Director", NormalizedName = "DIRECTOR", ConcurrencyStamp = Guid.NewGuid().ToString() },

                new AppRole {Id = 3, Name = "Employee", NormalizedName = "EMPLOYEE", ConcurrencyStamp = Guid.NewGuid().ToString() }
                
                );
        }
    }
}
