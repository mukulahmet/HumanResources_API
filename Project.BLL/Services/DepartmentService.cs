using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Department;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using Project.Models.Concrete;

namespace Project.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Department> AddDepartmentAsync(AddDepartmentDTO department)
        {
            Department newDepartment = new Department();
            _mapper.Map(department, newDepartment);
            return await _departmentRepository.AddAsync(newDepartment);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteAsync(id);
        }

        public async Task<Department> FindDepartmentAsync(int id)
        {
            return await _departmentRepository.FindAsync(id);
        }

        public async Task<IEnumerable<ListDepartmentDTO>> GetAllDepartmentAsync()
        {
            List<ListDepartmentDTO> departmentList = new List<ListDepartmentDTO>();
            var departments = await _departmentRepository.GetAllAsync();
            _mapper.Map(departments, departmentList);

            return departmentList;
        }

        public async Task<int> UpdateDepartmentAsync(int id, UpdateDepartmentDTO department)
        {
            var updateDepartment = await _departmentRepository.FindAsync(id);
            updateDepartment.DepartmentName = department.DepartmentName;
            return await _departmentRepository.UpdateAsync(updateDepartment);
        }
    }
}
