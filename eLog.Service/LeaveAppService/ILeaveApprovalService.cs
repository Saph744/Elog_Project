using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.LeaveAppService
{
    public interface ILeaveApprovalService:IService
    {
        Task<IList<LeaveApprovalViewModel>> GetAllAsync();

        Task<LeaveApprovalViewModel> GetByIdAsync(int leaveApprovalId);

        Task<LeaveApprovalViewModel> GetDataByIdAsync(int contactID);

        Task<string> InsertAsync(LeaveApprovalViewModel leaveappModel);

        Task<string> InsertRequestAsync(LeaveApprovalViewModel leaveappModel);

        Task<LeaveApprovalViewModel> UpdateAsync(LeaveApprovalViewModel leaveappModel);

        Task<LeaveApprovalViewModel> DeleteAsync(int leaveApprovalId);
    }
}
