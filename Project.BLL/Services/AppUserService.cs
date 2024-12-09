using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Models.ViewModels.AppUser;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using Project.Models.Concrete;
using Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppUserService(IAppUserRepository userRepository, IMapper _mappeer, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = _mappeer;
            _userManager = userManager;
        }

        public async Task<AppUser> AddNewDirectorAsync(AddDirectorDTO user)
        {
            AppUser appUser = new AppUser();
            _mapper.Map(user, appUser);

            appUser.NormalizedEmail = user.Email.ToUpper();
            appUser.UserName = (user.Name + user.SecondName +   user.LastName + user.SecondLastName).ToLower();
            appUser.NormalizedUserName = appUser.UserName.ToUpper();

            
            appUser.SecurityStamp = Guid.NewGuid().ToString();
            appUser.ConcurrencyStamp = Guid.NewGuid().ToString();

            string password = user.Name.ToLower() + "_B123";

            appUser.PasswordHash = _userManager.PasswordHasher.HashPassword(appUser, password);


            appUser.ActivityStatus = ActivityStatus.Avaliable;


			var createUserResult = await _userManager.CreateAsync(appUser, password); 
            if (!createUserResult.Succeeded)
            {
               
                throw new Exception($"olusum basarisiz: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
            }

       
            var roleAssignResult = await _userManager.AddToRoleAsync(appUser, "Director");
            if (!roleAssignResult.Succeeded)
            {
     
                throw new Exception($"Rol atama basarisiz: {string.Join(", ", roleAssignResult.Errors.Select(e => e.Description))}");
            }

            return appUser;
        }

		public async Task<AppUser> AddNewEmployeeAsync(AddEmployeeDTO user)
		{
			AppUser appUser = new AppUser();
			_mapper.Map(user, appUser);

			appUser.NormalizedEmail = user.Email.ToUpper();
			appUser.UserName = (user.Name + user.SecondName + user.LastName + user.SecondLastName).ToLower();
			appUser.NormalizedUserName = appUser.UserName.ToUpper();


			appUser.SecurityStamp = Guid.NewGuid().ToString();
			appUser.ConcurrencyStamp = Guid.NewGuid().ToString();

			string password = user.Name.ToLower() + "_B123";

			appUser.PasswordHash = _userManager.PasswordHasher.HashPassword(appUser, password);


            appUser.ActivityStatus = ActivityStatus.Avaliable;


			var createUserResult = await _userManager.CreateAsync(appUser, password);
			if (!createUserResult.Succeeded)
			{

				throw new Exception($"olusum basarisiz: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
			}


			var roleAssignResult = await _userManager.AddToRoleAsync(appUser, "Employee");
			if (!roleAssignResult.Succeeded)
			{

				throw new Exception($"Rol atama basarisiz: {string.Join(", ", roleAssignResult.Errors.Select(e => e.Description))}");
			}

			return appUser;
		}

		public async Task<int> UpdateUserAsync(UpdateAppUserDTO userDto,int userID)
        {
           
            var appUser = await _userRepository.FindAsync(userID);
            if (appUser == null)
            {
                return 0; 
            }

            
            _mapper.Map(userDto, appUser);
            return await _userRepository.UpdateAsync(appUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
        public async Task<AppUser> FindUserAsync(int id)
        {
            return await _userRepository.FindAsync(id);
        }
        public async Task<IEnumerable<ListAppUserDTO>> GetAllAppUsersAsync()
        {
            List<ListAppUserDTO> appUsers = new List<ListAppUserDTO>();

            var users = await _userRepository.GetAllAsync();

            _mapper.Map(users, appUsers);
            
            return appUsers;
        }

        public async Task<AppUser> ValidateUserAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<ListDirectorDTO>> GetAllDirectorsAsync()
        {
            var directors = await _userManager.GetUsersInRoleAsync("Director");

            List<int> ids = new List<int>();

            foreach (var item in directors)
            {
                if (item.Status != Status.Passive)
                {
                    ids.Add(item.Id);
                }
            }

            var listDirectorsToList = await _userRepository.ListeleAsync(
                select: x => new ListDirectorDTO {Id = x.Id, Name = x.Name, SecondName = x.SecondName, LastName = x.LastName, SecondLastName = x.SecondLastName, Email = x.Email, PhoneNumber = x.PhoneNumber, CompanyName = x.Company.CompanyName },
                where: x => ids.Contains(x.Id),
                include: x => x.Include(x => x.Company),
                orderBy: null
                );

            return listDirectorsToList;
        }

		public async Task<IEnumerable<IndexUserDTO>> GetProfileInfoAsync(int id)
		{
            var userProfile = await _userRepository.ListeleAsync(
                select: x => new IndexUserDTO { Id = x.Id, Address = x.Address, Email = x.Email, ImagePath = x.ImagePath, Name = x.Name, PhoneNumber = x.PhoneNumber, DepartmentName = x.Department.DepartmentName, JobName = x.Job.JobName },
                where: x => x.Id.Equals(id),
                include: x => x.Include(x => x.Job).Include(x => x.Department)
                );

            return userProfile;
		}

		public async Task<UserDetailVM> GetProfileDetailAsync(int id)
        {
            var userProfileDetail = await _userRepository.ListeleAsync(
                select: x => new UserDetailVM { Id = x.Id, ActivityStatus = x.ActivityStatus.ToString(), Address = x.Address, BirthDate = x.BirthDate, BirthPlace = x.BirthPlace, DepartmentName = x.Department.DepartmentName, ImagePath = x.ImagePath, JobName = x.Job.JobName, Name = x.Name, SecondName = x.SecondName, LastName = x.LastName, SecondLastName = x.SecondLastName, Salary = x.Salary, TC = x.TC, StartDate = x.StartDate, TerminationDate = x.TerminationDate, Email = x.Email, PhoneNumber = x.PhoneNumber},
                where: x => x.Id.Equals(id),
                include: x => x.Include(x=>x.Job).Include(x=>x.Department));

            return userProfileDetail.First();
        }

	}
}
