using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public interface IRoleService:IService
    {
        Task<IEnumerable<RoleViewModel>> GellAllRolesAsync();
        Task<RoleViewModel> GetRoleAsync(int RoleID);
        Task<string> InsertRoleAsync(RoleViewModel roleViewModel);
        Task<RoleViewModel> UpdateRoleAsync(RoleViewModel roleViewModel);
        Task<RoleViewModel> DeleteRoleAsync(int RoleID);
    }
}
