﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
    public class Department:IBaseEntity
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status? Status { get; set; }

        public ICollection<DepartmentCompany>? DepartmentCompanies { get; set; }

        public ICollection<AppUser>? AppUsers { get; set; }

    }
}
