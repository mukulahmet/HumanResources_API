using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.ViewModels.Leave
{
    public class ListLeaveDirectorVM
    {
        public int LeaveID { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public int DayCount { get; set; }

        public string FirstName { get; set; }
        public string SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public DateTime? CreationDate { get; set; } //aynı zamanda talep tarihi 
    }
}
