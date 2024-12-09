using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Models.DTO_s.Leave;
using Project.BLL.Models.ViewModels.Leave;
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
	public class LeaveService : ILeaveService
	{
		private readonly IMapper _mapper;
		private readonly ILeaveRepository _leaveRepository;

		public LeaveService(IMapper mapper, ILeaveRepository leaveRepository)
		{
			_mapper = mapper;
			_leaveRepository = leaveRepository;
		}

		public async Task<Leave> AddNewLeaveAsync(AddLeaveDTO leave)
		{
			return await _leaveRepository.AddAsync(_mapper.Map<Leave>(leave));
		}

        public async Task<IEnumerable<ListLeaveDirectorVM>> CompanyLeavesAsync(int companyID)
        {
			var leaves = await _leaveRepository.ListeleAsync(
				select: x => new ListLeaveDirectorVM { FirstName = x.AppUser.Name, SecondFirstName = x.AppUser.SecondName, LastName = x.AppUser.LastName, SecondLastName = x.AppUser.SecondLastName, LeaveID = x.LeaveID, LeaveStartDate = x.LeaveStartDate, LeaveEndDate = x.LeaveEndDate, CreationDate = x.CreationDate, DayCount = x.DayCount, ApprovalStatus = x.ApprovalStatus, LeaveType = x.LeaveType },
				where: x => x.AppUser.CompanyID.Equals(companyID) && x.ApprovalStatus == Project.Models.Enums.ApprovalStatus.Pending,
				orderBy: x => x.OrderByDescending(x => x.CreationDate),
				include: x => x.Include(x => x.AppUser)
				);

			return leaves;
        }

        public async Task<bool> DeleteLeaveAsync(int id)
		{
			return await _leaveRepository.DeleteAsync(id);
		}

		public async Task<Leave> FindLeaveAsync(int id)
		{
			return await _leaveRepository.FindAsync(id);
		}

		public async Task<IEnumerable<ListLeaveDTO>> GetAllLeavesAsync()
		{
			return await _leaveRepository.GetAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<ListLeaveDTO>>(task.Result));
		}

		public async Task<int> UpdateLeaveAsync(UpdateLeaveDTO leave, int leaveID)
		{
			var leaveToUpdate = await _leaveRepository.FindAsync(leaveID);
			_mapper.Map(leave, leaveToUpdate);
			return await _leaveRepository.UpdateAsync(leaveToUpdate);


		}
	}
}
