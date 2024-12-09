using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
    public class Company:IBaseEntity
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string? LogoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? EmployeeCount { get; set; }
        public DateTime FoundationDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractExpirationDate { get; set; }


        // Bu bir denemedir...

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status? Status { get; set; }

        public ICollection<AppUser>? AppUsers { get; set; }
        public ICollection<DepartmentCompany>? CompanyDepartments { get; set; }



    }
}
