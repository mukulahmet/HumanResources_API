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
    public class SeedDepartmentCompany : IEntityTypeConfiguration<DepartmentCompany>
    {
        public void Configure(EntityTypeBuilder<DepartmentCompany> builder)
        {
            builder.HasData(
                new DepartmentCompany { DepartmentCompanyID = 1, DepartmentID = 1, CompanyID = 1 },
                new DepartmentCompany { DepartmentCompanyID = 2, DepartmentID = 1, CompanyID = 2 },
                new DepartmentCompany { DepartmentCompanyID = 3, DepartmentID = 1, CompanyID = 3 },
                new DepartmentCompany { DepartmentCompanyID = 4, DepartmentID = 2, CompanyID = 1 },
                new DepartmentCompany { DepartmentCompanyID = 5, DepartmentID = 2, CompanyID = 2 },
                new DepartmentCompany { DepartmentCompanyID = 6, DepartmentID = 2, CompanyID = 3 },
                new DepartmentCompany { DepartmentCompanyID = 7, DepartmentID = 3, CompanyID = 1 },
                new DepartmentCompany { DepartmentCompanyID = 8, DepartmentID = 3, CompanyID = 2 },
                new DepartmentCompany { DepartmentCompanyID = 9, DepartmentID = 3, CompanyID = 3 }
                );
        }
    }
}
