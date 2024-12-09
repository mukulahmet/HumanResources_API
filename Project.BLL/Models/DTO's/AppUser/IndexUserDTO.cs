using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.AppUser
{
	public class IndexUserDTO
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string JobName { get; set; }
        public string DepartmentName { get; set; }

    }
}
