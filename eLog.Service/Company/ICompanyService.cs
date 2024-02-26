using eLog.Domain.Service;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public interface ICompanyService: IService
    {
        Task<IEnumerable<CompanyViewModel>> GellAllCompanysAsync();
        Task<CompanyViewModel> GetCompanyAsync(int CompanyID);
        Task<string> InsertCompanyAsync(CompanyViewModel companyViewModel);
        Task<CompanyViewModel> UpdateCompanyAsync(CompanyViewModel companyViewModel);
        Task<CompanyViewModel> DeleteCompanyAsync(int CompanyID);
      
    }
}
