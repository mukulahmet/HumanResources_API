using Project.BLL.Models.DTO_s;
using Project.BLL.Models.DTO_s.Company;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services.Abstracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<ListCompanyDTO>> GetAllCompanyAsync();
        Task<Company> AddCompanyAsync(AddCompanyDTO company);
        Task<bool> DeleteCompanyAsync(int companyID);
        Task<Company> FindCompanyAsync(int companyID);
        Task<int> UpdateCompanyAsync(UpdateCompanyDTO company, int companyID);

        Task<Company> FindCompanyWithID(int companyID);
        Task<DetailCompanyDTO> GetCompanyDetailAsync(int companyID);

	}
}
