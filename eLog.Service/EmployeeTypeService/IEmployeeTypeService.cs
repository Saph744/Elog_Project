using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public interface IEmployeeTypeService : IService
    {
        Task<IEnumerable<EmployeeTypeViewModel>> GetAllAsync();
        Task<EmployeeTypeViewModel> GetByIdAsync(int Id);
        Task<string> InsertAsync(EmployeeTypeViewModel viewEmployeeType);
        Task<EmployeeTypeViewModel> UpdateAsync(EmployeeTypeViewModel viewEmployeeType);
        Task<EmployeeTypeViewModel> DeleteAsync(int Id);
    }
}