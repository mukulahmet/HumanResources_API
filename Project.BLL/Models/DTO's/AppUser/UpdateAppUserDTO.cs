using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.AppUser
{
    public class UpdateAppUserDTO
    {

        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }

        public string TC { get; set; }
        public string? ImagePath { get; set; }

        public string? PhoneNumber { get; set; }

        public string Address { get; set; }
        public decimal? Salary { get; set; }


    }
}
