using Project.BLL.Models.DTO_s.Advance;
using Project.BLL.Models.DTO_s.Leave;
using Project.BLL.Models.ViewModels.Advance;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
	public interface IAdvanceService
	{
		Task<Advance> AddNewAdvanceAsync(AddAdvanceDTO advance);
		Task<int> UpdateAdvanceAsync(UpdateAdvanceDTO advance, int advanceID);
		Task<bool> DeleteAdvanceAsync(int id);
		Task<Advance> FindAdvanceAsync(int id);
		Task<IEnumerable<ListAdvanceDTO>> GetAllAdvancesAsync();
		Task<IEnumerable<ListAdvanceDTO>> FindUserAdvanceAsync(int userID);
		Task<IEnumerable<ListAdvanceDirectorVM>> GetCompanyAdvancesAsync(int companyID);
	}
}
