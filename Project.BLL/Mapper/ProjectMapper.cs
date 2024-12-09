using AutoMapper;
using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Advance;
using Project.BLL.Models.DTO_s.AppUser;
using Project.BLL.Models.DTO_s.Company;
using Project.BLL.Models.DTO_s.Department;
using Project.BLL.Models.DTO_s.Expense;
using Project.BLL.Models.DTO_s.Job;
using Project.BLL.Models.DTO_s.Leave;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Mapper
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<Company, AddCompanyDTO>().ReverseMap();
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
            CreateMap<Company, ListCompanyDTO>().ReverseMap();
            CreateMap<Company, DetailCompanyDTO>().ReverseMap();

            CreateMap<AppUser, AddAppUserDTO>().ReverseMap();
            CreateMap<AppUser, ListAppUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, ListDirectorDTO>().ReverseMap();
            CreateMap<AppUser, AddDirectorDTO>().ReverseMap();
			CreateMap<AppUser, AddEmployeeDTO>().ReverseMap();

			CreateMap<Job, AddJobDTO>().ReverseMap();
            CreateMap<Job, ListJobDTO>().ReverseMap();
            CreateMap<Job, UpdateJobDTO>().ReverseMap();

            CreateMap<Department, AddDepartmentDTO>().ReverseMap();
            CreateMap<Department, ListDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();


            CreateMap<Leave, AddLeaveDTO>().ReverseMap();    
            CreateMap<Leave, ListLeaveDTO>().ReverseMap();    
            CreateMap<Leave, UpdateLeaveDTO>().ReverseMap();    

            CreateMap<Expense, AddExpenseDTO>().ReverseMap();
            CreateMap<Expense, ListExpenseDTO>().ReverseMap();
            CreateMap<Expense, UpdateExpenseDTO>().ReverseMap();

            CreateMap<Advance,AddAdvanceDTO>().ReverseMap();
			CreateMap<Advance, ListAdvanceDTO>().ReverseMap();
			CreateMap<Advance, UpdateAdvanceDTO>().ReverseMap();
		}
    }
}
