using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public class CompanyService: ICompanyService
    {
        private IRepository<Company> _Companyrepository;
        private IDapperRepository _applicationReadDbConnection;     
        public CompanyService(IRepository<Company> repository, IDapperRepository applicationReadDbConnection)
        {
            _Companyrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection; 

        }
        public async Task<CompanyViewModel> DeleteCompanyAsync(int CompanyID)
        {
            var isCompanyExist = (await _Companyrepository.GetByIdAsync(x => x.CompanyID == CompanyID)).FirstOrDefault();
            if (isCompanyExist != null)
            {
                await _Companyrepository.DeleteAsync(isCompanyExist);
                await _Companyrepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<CompanyViewModel>> GellAllCompanysAsync()
        {
        
            var query = $"SELECT * FROM Company";
            var company = await _applicationReadDbConnection.QueryAsync<CompanyViewModel>(query);
            return company.ToList();
                                                             
        }
        public async Task<CompanyViewModel> GetCompanyAsync(int CompanyID)
        {
            var result = await _Companyrepository.GetByIdAsync(x => x.CompanyID == CompanyID);
            var company = result.Select(x => new CompanyViewModel
            {
                CompanyID = x.CompanyID,
                CompanyName = x.CompanyName,
                CompanyAbbreviation = x.CompanyAbbreviation,
                PhoneNumber = x.PhoneNumber,
                Extension = x.Extension,
                FaxNumber = x.FaxNumber,
                EmailAddress = x.EmailAddress,
                Website = x.Website,
                Country = x.Country,
                CountryCode = x.CountryCode,
                State = x.State,
                City = x.City,
                Address = x.Address,
                ImageName = x.ImageName,
                ImageFilePath = x.ImageFilePath,
                ModifiedTS =x.ModifiedTS,
                ModifiedBy = x.ModifiedBy,

            }).FirstOrDefault();
            return company;

        }
        public async Task<string> InsertCompanyAsync(CompanyViewModel companyViewModel)
        {
            string result;
            var company = new Company();
            var isCompanyNumberExist = (await _Companyrepository.GetByIdAsync(x => x.PhoneNumber == companyViewModel.PhoneNumber)).Any();
            if (isCompanyNumberExist)
            {
                result = "PhoneNumber Already Exist";
            }
            else
            {
                company.CompanyName = companyViewModel.CompanyName;
                company.CompanyAbbreviation = companyViewModel.CompanyAbbreviation;
                company.PhoneNumber = companyViewModel.PhoneNumber;
                company.Extension = companyViewModel.Extension;
                company.FaxNumber = companyViewModel.FaxNumber;
                company.EmailAddress = companyViewModel.EmailAddress;
                company.Website = companyViewModel.Website;
                company.Country = companyViewModel.Country;
                company.State = companyViewModel.State;
                company.City = companyViewModel.City;
                company.Address = companyViewModel.Address;
                company.ImageName = companyViewModel.ImageName;
                company.ImageFilePath = companyViewModel.ImageFilePath;  
                company.CreatedBy = companyViewModel.CreatedBy;
                company.CreatedTS = DateTime.Now;

                await _Companyrepository.InsertAsync(company);
                await _Companyrepository.SaveChangesAsync();
                result = "Added Successfully!";
            }

            return result;
        }
        public async Task<CompanyViewModel> UpdateCompanyAsync(CompanyViewModel companyViewModel)
        {
            var doesCompanyExist = (await _Companyrepository.GetByIdAsync(x => x.CompanyID == companyViewModel.CompanyID)).FirstOrDefault();
            if (doesCompanyExist != null)
            {

                doesCompanyExist.CompanyName = companyViewModel.CompanyName;
                doesCompanyExist.CompanyAbbreviation = companyViewModel.CompanyAbbreviation;
                doesCompanyExist.PhoneNumber = companyViewModel.PhoneNumber;
                doesCompanyExist.Extension = companyViewModel.Extension;
                doesCompanyExist.FaxNumber = companyViewModel.FaxNumber;
                doesCompanyExist.EmailAddress = companyViewModel.EmailAddress;
                doesCompanyExist.Website = companyViewModel.Website;
                doesCompanyExist.Country = companyViewModel.Country;
                doesCompanyExist.State = companyViewModel.State;
                doesCompanyExist.City = companyViewModel.City;
                doesCompanyExist.Address = companyViewModel.Address;
                doesCompanyExist.ImageName = companyViewModel.ImageName;
                doesCompanyExist.ImageFilePath = companyViewModel.ImageFilePath;
                doesCompanyExist.ModifiedTS = DateTime.Now;
                doesCompanyExist.ModifiedBy = companyViewModel.ModifiedBy;
               

                await _Companyrepository.UpdateAsync(doesCompanyExist);
                await _Companyrepository.SaveChangesAsync();
            }
            return companyViewModel;
        }
    }
}

