using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.LeaveTypeService
{
    public interface ILeaveTypeService:IService
    {
        Task<IList<LeaveTypeViewModel>> GetAllAsync();

        Task<LeaveTypeViewModel> GetByIdAsync(int leaveTypeID);

        Task<string> InsertAsync(LeaveTypeViewModel leaveTypeModel);

        Task<LeaveTypeViewModel> UpdateAsync(LeaveTypeViewModel leaveTypeModel);

        Task<LeaveTypeViewModel> DeleteAsync(int leaveTypeID);
    }
}
