using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;
using System.Linq;

namespace eLog.Service.LeaveAppService
{
    public class LeaveApprovalService : ILeaveApprovalService
    {
        private readonly IRepository<LeaveApproval> _leaveappRepository;
 
      
        private readonly IDapperRepository _applicationReadDbConnection;
        public LeaveApprovalService(IRepository<LeaveApproval> leaveappRepository,IDapperRepository applicationReadDbConnection)
        {
            _leaveappRepository = leaveappRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }

        public async Task<LeaveApprovalViewModel> DeleteAsync(int leaveApprovalId)
        {
            var result = (await _leaveappRepository.GetByIdAsync(x => x.LeaveApprovalID == leaveApprovalId)).FirstOrDefault();
            if (result != null)
            {
                await _leaveappRepository.DeleteAsync(result);
                await _leaveappRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IList<LeaveApprovalViewModel>> GetAllAsync()
        {
            var query = $"SELECT StartDate,EndDate,DaysOff,HourOff,NoticePeriod,LeavePolicyID," +
                $"LeaveReason,ApprovalStatus,LeaveReason,Description,EmployeeID" +
                $" From LeaveApproval INNER JOIN LeaveType on LeaveApproval.LeaveTypeID = LeaveType.LeaveTypeID";
            var leaveApproval = await _applicationReadDbConnection.QueryAsync<LeaveApprovalViewModel>(query);
            return leaveApproval.ToList();
        }

        public async Task<LeaveApprovalViewModel> GetByIdAsync(int leaveApprovalId)
        {
            var result = await _leaveappRepository.GetByIdAsync(x => x.LeaveApprovalID == leaveApprovalId);
            var leaveapproval = result.Select(x => new LeaveApprovalViewModel
            {
                LeaveApprovalID = x.LeaveApprovalID,
                DaysOff = x.DaysOff,
                HourOff = x.HourOff,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                LeaveReason = x.LeaveReason,
                ApprovalStatus = x.ApprovalStatus,
                NoticePeriod = x.NoticePeriod,
                LeavePolicyID = x.LeavePolicyID,
                LeaveTypeID=x.LeaveTypeID,

            }).FirstOrDefault();
            return leaveapproval;
        }

        public async Task<LeaveApprovalViewModel> GetDataByIdAsync(int contactID)
        {
            var query = $"SELECT LeaveApproval.EmployeeID AS EmpID From Contact INNER JOIN Employee ON Contact.ContactID=Employee.ContactID INNER JOIN LeaveApproval ON  LeaveApproval.EmployeeID = Employee.EmployeeID where Contact.ContactID = @contactID";
            var EmployeeID = await _applicationReadDbConnection.QueryFirstOrDefaultAsync<LeaveApprovalViewModel>(query, new { contactID });

            return EmployeeID;

        }

        public async Task<string> InsertAsync(LeaveApprovalViewModel leaveappModel)
        {
            string result;
            var leaveapp = new LeaveApproval();

            var isLeaveID = (await _leaveappRepository.GetByIdAsync(x => x.LeaveApprovalID == leaveapp.LeaveApprovalID)).Any();
            if (isLeaveID)
            {
                result = "LeaveID Already Exists";
            }
            else
            {
                leaveapp.CompanyID = leaveappModel.CompanyID;
                leaveapp.StartDate = leaveappModel.StartDate;
                leaveapp.EndDate = leaveappModel.EndDate;
                leaveapp.DaysOff = leaveappModel.DaysOff;
                leaveapp.HourOff = leaveappModel.HourOff;
                leaveapp.LeaveReason = leaveappModel.LeaveReason;
                leaveapp.ApprovalStatus = leaveappModel.ApprovalStatus;
                leaveapp.NoticePeriod = leaveappModel.NoticePeriod;
                leaveapp.EmployeeID = leaveappModel.EmployeeID;
                leaveapp.LeaveTypeID = leaveappModel.LeaveTypeID;
                leaveapp.LeavePolicyID = leaveappModel.LeavePolicyID;
                leaveapp.CreatedTS = DateTime.Now;

                await _leaveappRepository.InsertAsync(leaveapp);
                await _leaveappRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result; 
        }

        public async Task<string> InsertRequestAsync(LeaveApprovalViewModel leaveappModel)
        {
       

            string result;
           
                var leaveReq = new LeaveApproval()
            {
                LeaveApprovalID = leaveappModel.LeaveApprovalID,
                LeaveReason = leaveappModel.LeaveReason,
                StartDate = leaveappModel.StartDate,
                EndDate = leaveappModel.EndDate,
                DaysOff = leaveappModel.DaysOff,
                HourOff = leaveappModel.HourOff,
               ApprovalStatus = leaveappModel.ApprovalStatus,
                EmployeeID= leaveappModel.EmpID,
                LeaveTypeID = leaveappModel.LeaveTypeID,
                CreatedTS = DateTime.Now,

            };
            await _leaveappRepository.InsertAsync(leaveReq);
            await _leaveappRepository.SaveChangesAsync();
            result = "Data Addded Sucessfully";
            return result;
        }
      

        public async Task<LeaveApprovalViewModel> UpdateAsync(LeaveApprovalViewModel leaveappModel)
        {
            var leaveApprovalExist = (await _leaveappRepository.GetByIdAsync(x => x.LeaveApprovalID == leaveappModel.LeaveApprovalID)).FirstOrDefault();
            if (leaveApprovalExist != null)
            {
                leaveApprovalExist.StartDate = leaveappModel.StartDate;
                leaveApprovalExist.EndDate = leaveappModel.EndDate;
                leaveApprovalExist.DaysOff = leaveappModel.DaysOff;
                leaveApprovalExist.HourOff = leaveappModel.HourOff;
                leaveApprovalExist.LeaveReason = leaveappModel.LeaveReason;
                leaveApprovalExist.ApprovalStatus = leaveappModel.ApprovalStatus;
                leaveApprovalExist.NoticePeriod = leaveappModel.NoticePeriod;
                leaveApprovalExist.LeaveTypeID = leaveappModel.LeaveTypeID;
                leaveApprovalExist.LeavePolicyID = leaveappModel.LeavePolicyID;
                leaveApprovalExist.EmployeeID = leaveappModel.EmployeeID;

                await _leaveappRepository.UpdateAsync(leaveApprovalExist);
                await _leaveappRepository.SaveChangesAsync();
            }
            return leaveappModel;
        }
    }
}
