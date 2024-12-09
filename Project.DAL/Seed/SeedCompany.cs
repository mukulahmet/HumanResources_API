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
    public class SeedCompany : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    CompanyID = 1,
                    CompanyName = "myob",
                    CompanyTitle = "Ltd.sti",
                    MersisNo = "01111111111111115",
                    TaxNo = "9111111111",
                    TaxOffice = "İstanbul Vergi Dairesi",
                    PhoneNumber = "0111 222 3344",
                    Address = "İstanbul",
                    Email = "myob@support.com",
                    FoundationDate = new DateTime(2002, 1, 1),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "\\LandingPage\\assets\\img\\clients\\client-1.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 2,
                    CompanyName = "Belimo",
                    CompanyTitle = "A.Ş.",
                    MersisNo = "02222222222222226",
                    TaxNo = "9222222222",
                    TaxOffice = "Ankara Vergi Dairesi",
                    PhoneNumber = "0222 333 4455",
                    Address = "Ankara",
                    Email = "belimo@support.com",
                    FoundationDate = new DateTime(2005, 5, 15),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-2.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 3,
                    CompanyName = "LifeGroups",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "lifegroups@support.com",
                    FoundationDate = new DateTime(2010, 10, 20),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-3.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 4,
                    CompanyName = "grabyo",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "grabyo@support.com",
                    FoundationDate = new DateTime(2010, 10, 20),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-4.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 5,
                    CompanyName = "citrus",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "citrus@support.com",
                    FoundationDate = new DateTime(2010, 5, 28),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "\\LandingPage\\assets\\img\\clients\\client-5.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 6,
                    CompanyName = "Trustly",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "trustly@support.com",
                    FoundationDate = new DateTime(2010, 1, 28),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-6.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 7,
                    CompanyName = "oldendoff",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "oldendoff@support.com",
                    FoundationDate = new DateTime(2010, 9, 29),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-7.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                },
                new Company
                {
                    CompanyID = 8,
                    CompanyName = "Lilly",
                    CompanyTitle = "Ltd. Şti.",
                    MersisNo = "03333333333333337",
                    TaxNo = "9333333333",
                    TaxOffice = "İzmir Vergi Dairesi",
                    PhoneNumber = "0333 444 5566",
                    Address = "İzmir",
                    Email = "lilly@support.com",
                    FoundationDate = new DateTime(2010, 4, 16),
                    Status = Models.Enums.Status.Active,
                    LogoPath = "/LandingPage/assets/img/clients/client-8.png",
                    EmployeeCount = 15,
                    ContractStartDate = new DateTime(2018, 4, 3),
                    ContractExpirationDate = new DateTime(2028, 4, 3)
                }

                );

        }
    }
}
