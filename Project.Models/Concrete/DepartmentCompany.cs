using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
    public class DepartmentCompany:IBaseEntity
    {
        public int DepartmentCompanyID { get; set; }

        public int DepartmentID { get; set; }
        public Department? Department { get; set; }

        public int CompanyID { get; set; }
        public Company? Company { get; set;}


        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status? Status { get; set; }
    }
}
