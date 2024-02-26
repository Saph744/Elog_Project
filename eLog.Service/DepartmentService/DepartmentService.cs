using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IRepository<Department> _departmentRepository;
        private IDapperRepository _applicationReadDbConnection;
        public DepartmentService(IRepository<Department> repository, IDapperRepository applicationReadDbConnection)
        {
            _departmentRepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<DepartmentViewModel> DeleteAsync(int Id)
        {
            var isDepartmentExist = (await _departmentRepository.GetByIdAsync(x => x.DepartmentID == Id)).FirstOrDefault();
            if (isDepartmentExist != null)
            {
                await _departmentRepository.DeleteAsync(isDepartmentExist);
                await _departmentRepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<DepartmentViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM Department";
            var department = await _applicationReadDbConnection.QueryAsync<DepartmentViewModel>(query);
            return department.ToList();
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int Id)
        {
            var result = await _departmentRepository.GetByIdAsync(x => x.DepartmentID == Id);
            var department = result.Select(x => new DepartmentViewModel
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                CompanyID = x.CompanyID,
            }).FirstOrDefault();
            return department;
        }

        public async Task<string> InsertAsync(DepartmentViewModel viewDepartment)
        {
            string result;
            var department = new Department();

            var isDepartmentIDExist = (await _departmentRepository.GetByIdAsync(x => x.DepartmentID == viewDepartment.DepartmentID)).Any();
            if (isDepartmentIDExist)
            {
                result = "department Already Exist";
            }
            else
            {
                department.DepartmentID = viewDepartment.DepartmentID;
                department.DepartmentName = viewDepartment.DepartmentName;
                department.CompanyID = viewDepartment.CompanyID;
                department.CreatedTS = DateTime.Now;

                await _departmentRepository.InsertAsync(department);
                await _departmentRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<DepartmentViewModel> UpdateAsync(DepartmentViewModel viewDepartment)
        {
            var doesDepartmentExist = (await _departmentRepository.GetByIdAsync(x => x.DepartmentID == viewDepartment.DepartmentID)).FirstOrDefault();
            if (doesDepartmentExist != null)
            {
                doesDepartmentExist.DepartmentID = viewDepartment.DepartmentID;
                doesDepartmentExist.DepartmentName = viewDepartment.DepartmentName;
                doesDepartmentExist.CompanyID = viewDepartment.CompanyID;

                await _departmentRepository.UpdateAsync(doesDepartmentExist);
                await _departmentRepository.SaveChangesAsync();
            }
            return viewDepartment;
        }
    }
}
