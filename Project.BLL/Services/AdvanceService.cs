using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Models.DTO_s.Advance;
using Project.BLL.Models.ViewModels.Advance;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
	public class AdvanceService : IAdvanceService
	{
		private readonly IMapper _mapper;
		private readonly IAdvanceRepository _advanceRepository;

		public AdvanceService(IMapper mapper, IAdvanceRepository advanceRepository)
		{
			_mapper = mapper;
			_advanceRepository = advanceRepository;
		}

		public async Task<Advance> AddNewAdvanceAsync(AddAdvanceDTO advance)
		{
			return await _advanceRepository.AddAsync(_mapper.Map<Advance>(advance));
		}

		public async Task<bool> DeleteAdvanceAsync(int id)
		{
			return await _advanceRepository.DeleteAsync(id);
		}

		public async Task<Advance> FindAdvanceAsync(int id)
		{
			return await _advanceRepository.FindAsync(id);
		}

		public async Task<IEnumerable<ListAdvanceDTO>> FindUserAdvanceAsync(int userID)
		{
			var userAdvances = await _advanceRepository.ListeleAsync(
				select: x => x,
				where: x => x.AppUserID.Equals(userID),
				orderBy: x => x.OrderByDescending(x => x.CreationDate));

			List<ListAdvanceDTO> listUserAdvances = new List<ListAdvanceDTO>();

			_mapper.Map(userAdvances, listUserAdvances);

			return listUserAdvances;
		}

		public async Task<IEnumerable<ListAdvanceDTO>> GetAllAdvancesAsync()
		{
			return await _advanceRepository.GetAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<ListAdvanceDTO>>(task.Result));
		}

        public async Task<IEnumerable<ListAdvanceDirectorVM>> GetCompanyAdvancesAsync(int companyID)
        {
			return await _advanceRepository.ListeleAsync(
				select: x => new ListAdvanceDirectorVM { FirstName = x.AppUser.Name, SecondFirstName = x.AppUser.SecondName, LastName = x.AppUser.LastName, SecondLastName = x.AppUser.SecondLastName, AdvanceType = x.AdvanceType.ToString(), AdvanceID = x.AdvanceID, Amount = x.Amount, CreationDate = x.CreationDate, Currency = x.Currency.ToString(), Description = x.Description},
				where: x => x.ApprovalStatus == Project.Models.Enums.ApprovalStatus.Pending && x.AppUser.CompanyID.Equals(companyID),
				orderBy: x => x.OrderByDescending(x => x.CreationDate),
				include: x => x.Include(x => x.AppUser)
				);
        }

        public async Task<int> UpdateAdvanceAsync(UpdateAdvanceDTO advance, int advanceID)
		{
			var advanceToUpdate = await _advanceRepository.FindAsync(advanceID);

			_mapper.Map(advance, advanceToUpdate);
			return await _advanceRepository.UpdateAsync(advanceToUpdate);
		}
	}
}
