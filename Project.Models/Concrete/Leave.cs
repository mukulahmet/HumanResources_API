using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
	public class Leave : IBaseEntity
	{
		public Leave()
		{
			//TimeSpan difference = LeaveEndDate - LeaveStartDate;
			//DayCount = difference.Days;

			ApprovalStatus = ApprovalStatus.Pending;
		}
     
      
        public int LeaveID { get; set; }
		public LeaveType LeaveType { get; set; }
		public DateTime LeaveStartDate { get; set; }
		public DateTime LeaveEndDate { get; set; }
		public int DayCount { 
			get
			{
                TimeSpan difference = LeaveEndDate - LeaveStartDate;
                return difference.Days;
            }
		}
		public ApprovalStatus ApprovalStatus { get; set; }


        public DateTime? CreationDate { get; set; } //aynı zamanda talep tarihi 
		public DateTime? ModifiedDate { get; set; } //cevaplanma tarihi
		public DateTime? DeletedDate { get; set; }
		public Status? Status { get; set; }


        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

    }
}
