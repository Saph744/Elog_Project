using eLog.Repository;
using eLog.Domain.Models;
using eLog.Service.ViewModels;

namespace eLog.Service.UserLeaveDetailService
{
    public class UserLeaveDetailService : IUserLeaveDetailService
    {
        private readonly IRepository<UserLeaveDetail> _userLeaveDetailRepository;
        private IDapperRepository _applicationReadDbConnection;
        public UserLeaveDetailService(IRepository<UserLeaveDetail> UserLeaveDetailRepository, IDapperRepository applicationReadDbConnection)
        {
            _userLeaveDetailRepository = UserLeaveDetailRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<UserLeaveDetailViewModel> DeleteUserLeaveAsync(int userLeaveId)
        {
            var isUserLeaveExist = (await _userLeaveDetailRepository.GetByIdAsync(x => x.UserLeaveID == userLeaveId)).FirstOrDefault();
            if (isUserLeaveExist != null)
            {
                await _userLeaveDetailRepository.DeleteAsync(isUserLeaveExist);
                await _userLeaveDetailRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<UserLeaveDetailViewModel>> GetAllUserLeaveAsync()
        {
            var query = $"SELECT Description,YTDEarned,YTDConsumed,PendingApproval,BalanceAvailable  FROM UserLeaveDetail" +
                $" INNER JOIN LeaveType ON UserLeaveDetail.LeaveTypeID = LeaveType.LeaveTypeID   ";
            var userLeaveDetail = await _applicationReadDbConnection.QueryAsync<UserLeaveDetailViewModel>(query);
            return userLeaveDetail.ToList();
        }
         
        public async Task<UserLeaveDetailViewModel> GetUserLeaveByIDAsync(int userLeaveId)
        {
            var result = await _userLeaveDetailRepository.GetByIdAsync(x => x.UserLeaveID == userLeaveId);
            var userLeaveDetail = result.Select(x => new UserLeaveDetailViewModel
            {
                UserLeaveID = x.UserLeaveID,
                EmployeeID = x.EmployeeID,
                CompanyID = x.CompanyID,
                LeaveTypeID = x.LeaveTypeID,
                YTDEarned = x.YTDEarned,
                YTDConsumed = x.YTDConsumed,
                PendingApproval = x.PendingApproval,
                BalanceAvailable = x.BalanceAvailable,

            }).FirstOrDefault();
            return userLeaveDetail;
        }

        public async Task<string> InsertUserLeaveAsync(UserLeaveDetailViewModel userLeaveDetailModel)
        {
            string result;
            var userDetail = new UserLeaveDetail();

            var isuserLeaveID = (await _userLeaveDetailRepository.GetByIdAsync(x => x.UserLeaveID == userDetail.UserLeaveID)).Any();
            if (isuserLeaveID)
            {
                result = "UserLeaveID Already Exists";
            }
            else
            {
                userDetail.CompanyID = userLeaveDetailModel.CompanyID;
                userDetail.EmployeeID = userLeaveDetailModel.EmployeeID;
                userDetail.LeaveTypeID = userLeaveDetailModel.LeaveTypeID;
                userDetail.YTDEarned = userLeaveDetailModel.YTDEarned;
                userDetail.YTDConsumed = userLeaveDetailModel.YTDConsumed;
                userDetail.PendingApproval = userLeaveDetailModel.PendingApproval;
                userDetail.BalanceAvailable = userDetail.YTDEarned-userDetail.YTDConsumed;
                userDetail.CreatedBy = userLeaveDetailModel.CreatedBy;
                userDetail.CreatedTS = DateTime.Now;

                await _userLeaveDetailRepository.InsertAsync(userDetail);
                await _userLeaveDetailRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<UserLeaveDetailViewModel> UpdateUserLeaveAsync(UserLeaveDetailViewModel userLeaveDetailModel)
        {
            var userleaveExist = (await _userLeaveDetailRepository.GetByIdAsync(x => x.UserLeaveID == userLeaveDetailModel.UserLeaveID)).FirstOrDefault();
            if (userleaveExist != null)
            {
                userleaveExist.CompanyID = userLeaveDetailModel.CompanyID;
                userleaveExist.LeaveTypeID = userLeaveDetailModel.LeaveTypeID;
                userleaveExist.EmployeeID = userLeaveDetailModel.EmployeeID;
                userleaveExist.YTDEarned = userLeaveDetailModel.YTDEarned;
                userleaveExist.YTDConsumed = userLeaveDetailModel.YTDConsumed;
                userleaveExist.PendingApproval = userLeaveDetailModel.PendingApproval;
                userleaveExist.BalanceAvailable = userLeaveDetailModel.BalanceAvailable;

                await _userLeaveDetailRepository.UpdateAsync(userleaveExist);
                await _userLeaveDetailRepository.SaveChangesAsync();
            }
            return userLeaveDetailModel;
        }
    }
}
