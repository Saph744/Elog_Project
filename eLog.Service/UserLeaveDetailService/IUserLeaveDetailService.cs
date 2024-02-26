using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.UserLeaveDetailService
{
    public interface IUserLeaveDetailService:IService
    {
        Task<IEnumerable<UserLeaveDetailViewModel>> GetAllUserLeaveAsync();

        Task<UserLeaveDetailViewModel> GetUserLeaveByIDAsync(int userLeaveId);

        Task<string> InsertUserLeaveAsync(UserLeaveDetailViewModel userLeaveDetailModel);

        Task <UserLeaveDetailViewModel> UpdateUserLeaveAsync(UserLeaveDetailViewModel userLeaveDetailModel);

        Task<UserLeaveDetailViewModel> DeleteUserLeaveAsync(int userLeaveId);

    }
}

