using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.AppUser
{
	public class AddDirectorDTO
	{
		public string Name { get; set; }
		public string? SecondName { get; set; }
		public string LastName { get; set; }
		public string? SecondLastName { get; set; }
		public string? ImagePath { get; set; }
		public DateTime BirthDate { get; set; }
		public string? BirthPlace { get; set; }
		public string TC { get; set; }
		public DateTime? StartDate { get; set; }
        public int JobID { get; set; }
        public int DepartmentID { get; set; }
        public string Email { get; set; }
		public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyID { get; set; }
    }
}
