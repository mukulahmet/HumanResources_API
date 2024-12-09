using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.Company
{
    public class ListCompanyDTO
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string? LogoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
