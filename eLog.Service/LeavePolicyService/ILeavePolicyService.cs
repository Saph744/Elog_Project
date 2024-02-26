using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.LeavePolicyService
{
    public interface ILeavePolicyService:IService
    {
        Task<IList<LeavePolicyViewModel>> GetAllAsync();

        Task<LeavePolicyViewModel> GetByIdAsync(int leavePolicyID);

        Task<string> InsertAsync(LeavePolicyViewModel leavePolicyModel);

        Task<LeavePolicyViewModel> UpdateAsync(LeavePolicyViewModel leavePolicyModel);

        Task<LeavePolicyViewModel> DeleteAsync(int leavePolicyID);
    }
}
