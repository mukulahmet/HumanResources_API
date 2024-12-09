using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
    public class AppUser : IdentityUser<int>,IBaseEntity
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string TC { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public ActivityStatus? ActivityStatus { get; set; }
        public string Address { get; set; }
        public decimal? Salary { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status? Status { get; set; }

        public int? JobID { get; set; }
        public Job? Job { get; set; }

        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }


        public ICollection<Leave>? Leaves { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Advance> Advances { get; set; }

    }
}
