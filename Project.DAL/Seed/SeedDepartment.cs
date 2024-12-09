using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Seed
{
    public class SeedDepartment : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department { DepartmentID = 1, DepartmentName = "Management" },
                new Department { DepartmentID = 2, DepartmentName = "Research And Development" },
                new Department { DepartmentID = 3, DepartmentName = "Programming" }

                );

        }
    }
}
