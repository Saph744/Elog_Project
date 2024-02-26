using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private IRepository<EmployeeType> _employeeTypeRepository;
        private IDapperRepository _applicationReadDbConnection;
        public EmployeeTypeService(IRepository<EmployeeType> EmployeeTypeRepository, IDapperRepository applicationReadDbConnection)
        {
            _employeeTypeRepository = EmployeeTypeRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<EmployeeTypeViewModel> DeleteAsync(int Id)
        {
            var isEmployeeTypeExist = (await _employeeTypeRepository.GetByIdAsync(x => x.EmployeeTypeID == Id)).FirstOrDefault();
            if (isEmployeeTypeExist != null)
            {
                await _employeeTypeRepository.DeleteAsync(isEmployeeTypeExist);
                await _employeeTypeRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeTypeViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM EmployeeType";
            var employeeType = await _applicationReadDbConnection.QueryAsync<EmployeeTypeViewModel>(query);
            return employeeType.ToList();
        }

        public async Task<EmployeeTypeViewModel> GetByIdAsync(int Id)
        {
            var result = await _employeeTypeRepository.GetByIdAsync(x => x.EmployeeTypeID == Id);
            var employeeType = result.Select(x => new EmployeeTypeViewModel
            {
                EmployeeTypeID = x.EmployeeTypeID,
                EmployeeTypes = x.EmployeeTypes,
                CompanyID = x.CompanyID,
            }).FirstOrDefault();
            return employeeType;
        }

        public async Task<string> InsertAsync(EmployeeTypeViewModel viewEmployeeType)
        {
            string result;
            var employeeType = new EmployeeType();

            var isEmployeeTypeIDExist = (await _employeeTypeRepository.GetByIdAsync(x => x.EmployeeTypeID == viewEmployeeType.EmployeeTypeID)).Any();
            if (isEmployeeTypeIDExist)
            {
                result = "EmployeeType Already Exist";
            }
            else
            {
                employeeType.EmployeeTypeID = viewEmployeeType.EmployeeTypeID;
                employeeType.EmployeeTypes = viewEmployeeType.EmployeeTypes;
                employeeType.CompanyID = viewEmployeeType.CompanyID;
                employeeType.CreatedTS = DateTime.Now;

                await _employeeTypeRepository.InsertAsync(employeeType);
                await _employeeTypeRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<EmployeeTypeViewModel> UpdateAsync(EmployeeTypeViewModel viewEmployeeType)
        {
            var doesEmployeeTypeExist = (await _employeeTypeRepository.GetByIdAsync(x => x.EmployeeTypeID == viewEmployeeType.EmployeeTypeID)).FirstOrDefault();
            if (doesEmployeeTypeExist != null)
            {
                doesEmployeeTypeExist.EmployeeTypeID = viewEmployeeType.EmployeeTypeID;
                doesEmployeeTypeExist.EmployeeTypes = viewEmployeeType.EmployeeTypes;
                doesEmployeeTypeExist.CompanyID = viewEmployeeType.CompanyID;
                await _employeeTypeRepository.UpdateAsync(doesEmployeeTypeExist);
                await _employeeTypeRepository.SaveChangesAsync();
            }
            return viewEmployeeType;
        }
    }
}
