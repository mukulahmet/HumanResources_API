using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Models.DTO_s.Advance
{
	public class ListAdvanceDTO
	{
		public int AdvanceID { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public decimal Amount { get; set; }
		public Currency Currency { get; set; }
		public string Description { get; set; }
		public AdvanceType AdvanceType { get; set; }

		public int AppUserID { get; set; }
	}
}
