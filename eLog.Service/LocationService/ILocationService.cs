using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public interface ILocationService : IService
    {
        Task<IEnumerable<LocationViewModel>> GetAllAsync();
        Task<LocationViewModel> GetByIdAsync(int Id);
        Task<string> InsertAsync(LocationViewModel viewLocation);
        Task<LocationViewModel> UpdateAsync(LocationViewModel viewLocation);
        Task<LocationViewModel> DeleteAsync(int Id);
    }
}
