using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModel;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public interface IEmployeeService : IService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllAsync();
       // Task<IEnumerable<EmployeeViewModel>> GetDataAsync();
        Task<EmployeeViewModel> GetByIdAsync(int Id);
        Task<string> InsertAsync(EmployeeViewModel viewEmployee);
       // Task<string> InsertDataAsync(EmployeeManagerViewModel viewModel);
        Task<EmployeeViewModel> UpdateAsync(EmployeeViewModel viewEmployee);
        Task<EmployeeViewModel> DeleteAsync(int Id);
    }
}