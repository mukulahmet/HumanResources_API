using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Models.ViewModels.AppUser;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
    public interface IAppUserService
    {
        Task<AppUser> AddNewDirectorAsync(AddDirectorDTO user);
		Task<AppUser> AddNewEmployeeAsync(AddEmployeeDTO user);
		Task<int> UpdateUserAsync(UpdateAppUserDTO user,int userID);
        Task<bool> DeleteUserAsync(int id);
        Task<AppUser> FindUserAsync(int id);
        Task<AppUser> ValidateUserAsync(string email, string password);
        Task<IEnumerable<ListAppUserDTO>> GetAllAppUsersAsync();

        Task<IEnumerable<ListDirectorDTO>> GetAllDirectorsAsync();

        Task<IEnumerable<IndexUserDTO>> GetProfileInfoAsync(int id);

        Task<UserDetailVM> GetProfileDetailAsync(int id);

    }
}
