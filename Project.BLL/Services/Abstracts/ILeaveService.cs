using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Models.DTO_s.Leave;
using Project.BLL.Models.ViewModels.Leave;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
	public interface ILeaveService
	{
		Task<Leave> AddNewLeaveAsync(AddLeaveDTO leave);
		Task<int> UpdateLeaveAsync(UpdateLeaveDTO leave, int leaveID);
		Task<bool> DeleteLeaveAsync(int id);
		Task<Leave> FindLeaveAsync(int id);
		Task<IEnumerable<ListLeaveDTO>> GetAllLeavesAsync();

		Task<IEnumerable<ListLeaveDirectorVM>> CompanyLeavesAsync(int companyID);

	}
}
