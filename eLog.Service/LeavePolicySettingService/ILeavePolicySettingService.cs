using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.LeavePolicySettingService
{
    public interface ILeavePolicySettingService:IService
    {
        Task<IList<LeavePolicySettingViewModel>> GetAllAsync();

        Task<LeavePolicySettingViewModel> GetByIdAsync(int leavePolicySettingID);

        Task<IList<LeavePolicySettingViewModel>> GetPolicyByIdAsync(int leavePolicyID);

        Task<string> InsertAsync(LeavePolicySettingViewModel leavePolicySettingModel);

        Task<LeavePolicySettingViewModel> UpdateAsync(LeavePolicySettingViewModel leavePolicySettingModel);

        Task<LeavePolicySettingViewModel> DeleteAsync(int leavePolicySettingID);
    }
}
