using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public interface IDepartmentService : IService
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int Id);
        Task<string> InsertAsync(DepartmentViewModel viewDepartment);
        Task<DepartmentViewModel> UpdateAsync(DepartmentViewModel viewDepartment);
        Task<DepartmentViewModel> DeleteAsync(int Id);
    }
}
