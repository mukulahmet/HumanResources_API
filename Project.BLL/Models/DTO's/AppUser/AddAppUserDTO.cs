using Azure.Identity;
using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.AppUser
{
    public class AddAppUserDTO
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }

        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string TC { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public ActivityStatus? ActivityStatus { get; set; }
        public string Address { get; set; }
        public decimal? Salary { get; set; }

        public string Password{ get; set; }
        public int? JobID { get; set; }
        public int? CompanyID { get; set; }

        public int? DepartmentID { get; set; }

        public Status status { get; set; } = Status.Active;
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
