using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Company;
using Project.BLL.Services.Abstracts;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyDepartmentRepository _companyDepartmentRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, ICompanyDepartmentRepository companyDepartmentRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _companyDepartmentRepository = companyDepartmentRepository;
        }

        public async Task<Company> AddCompanyAsync(AddCompanyDTO company)
        {
            Company newCompany = new Company();

            _mapper.Map(company, newCompany);

            var addedCompany = await _companyRepository.AddAsync(newCompany);

            foreach (int id in company.ListDepartmentID)
            {
                DepartmentCompany departmentCompany = new DepartmentCompany();

                departmentCompany.CompanyID = addedCompany.CompanyID;
                departmentCompany.DepartmentID = id;

                await _companyDepartmentRepository.AddAsync(departmentCompany);
            }

            return addedCompany;
        }

        public async Task<bool> DeleteCompanyAsync(int companyID)
        {
            var companyDepartments = await _companyDepartmentRepository.ListeleAsync(select: x => x,
                where: x => x.CompanyID == companyID);

            foreach (var department in companyDepartments)
            {
                await _companyDepartmentRepository.DeleteAsync(department.DepartmentCompanyID);
            }

            return await _companyRepository.DeleteAsync(companyID);
        }

        public async Task<int> UpdateCompanyAsync(UpdateCompanyDTO company, int companyID)
        {

            Company newUpdateCompany = new Company();
            newUpdateCompany.CompanyID = companyID;
            

            var departmentCompanies = await _companyDepartmentRepository.ListeleAsync(
                select: x => x,
                where: x => x.CompanyID.Equals(companyID));

            foreach(var department in departmentCompanies)
            {
                await _companyDepartmentRepository.HardDelete(department);
            }

            foreach(int departmentID in company.ListDepartmentID)
            {
                DepartmentCompany departmentCompany = new DepartmentCompany();
                departmentCompany.CompanyID = companyID;
                departmentCompany.DepartmentID = departmentID;

                await _companyDepartmentRepository.AddAsync(departmentCompany);
            }

            _mapper.Map(company, newUpdateCompany);

            return await _companyRepository.UpdateAsync(newUpdateCompany);
        }

        public async Task<Company> FindCompanyAsync(int companyID)
        {
            return await _companyRepository.FindAsync(companyID);
        }

		public async Task<DetailCompanyDTO> GetCompanyDetailAsync(int companyID)
		{
            DetailCompanyDTO companyDetail = new DetailCompanyDTO();

            var company = await _companyRepository.FindAsync(companyID);

            _mapper.Map(company, companyDetail);

            return companyDetail;
		}

		public async Task<IEnumerable<ListCompanyDTO>> GetAllCompanyAsync()
        {
            List<ListCompanyDTO> companyList = new List<ListCompanyDTO>();

            var companies = await _companyRepository.GetAllAsync();

            _mapper.Map(companies, companyList);

            return companyList;
        }

        public async Task<Company> FindCompanyWithID(int companyID)
        {
            var company = await _companyRepository.ListeleAsync(
                select: x => x,
                where: x => x.CompanyID == companyID,
                orderBy: null,
                include: x => x.Include(x => x.AppUsers)
                );

            return company.SingleOrDefault();
        }
    }
}
