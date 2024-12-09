using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.Leave
{
	public class ListLeaveDTO
	{
        public int LeaveID { get; set; }
		public LeaveType LeaveType { get; set; }
		public DateTime LeaveStartDate { get; set; }
		public DateTime LeaveEndDate { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
        public int DayCount { get; set; }

        public int AppUserID { get; set; }


	}
}
