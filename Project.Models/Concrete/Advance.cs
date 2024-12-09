using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models.Abstract;
using Project.Models.Enums;

namespace Project.Models.Concrete
{
	public class Advance:IBaseEntity
	{
        public Advance()
        {
            ApprovalStatus = ApprovalStatus.Pending;
        }
        public int AdvanceID { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
		public decimal Amount { get; set; }
		public Currency Currency { get; set; }
        public string Description { get; set; }
        public AdvanceType AdvanceType { get; set; }


        public DateTime? CreationDate { get; set; } //aynı zamanda talep tarihi 
		public DateTime? ModifiedDate { get; set; } //cevaplanma tarihi
		public DateTime? DeletedDate { get; set; }
		public Status? Status { get; set; }


		public int AppUserID { get; set; }
		public AppUser AppUser { get; set; }

	}
}
