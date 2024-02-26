using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.LeavePolicyService
{
    public class LeavePolicyService : ILeavePolicyService
    {
        private readonly IRepository<LeavePolicy> _leavePolicyRepo;
        private readonly IDapperRepository _applicationReadDbConnection;
        public LeavePolicyService(IRepository<LeavePolicy> leavePolicyRepo, IDapperRepository applicationReadDbConnection)
        {
            _leavePolicyRepo = leavePolicyRepo;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<LeavePolicyViewModel> DeleteAsync(int leavePolicyID)
        {
            var result = (await _leavePolicyRepo.GetByIdAsync(x => x.LeavePolicyID == leavePolicyID)).FirstOrDefault();
            if (result != null)
            {
                await _leavePolicyRepo.DeleteAsync(result);
                await _leavePolicyRepo.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IList<LeavePolicyViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM LeavePolicy";
            var leavePolicy = await _applicationReadDbConnection.QueryAsync<LeavePolicyViewModel>(query);
            return leavePolicy.ToList();
        }

        public async Task<LeavePolicyViewModel> GetByIdAsync(int leavePolicyID)
        {
            var result = await _leavePolicyRepo.GetByIdAsync(x => x.LeavePolicyID == leavePolicyID);
            var leavePolicy = result.Select(x => new LeavePolicyViewModel
            {
                LeavePolicyID = x.LeavePolicyID,
                CompanyID = x.CompanyID,
                Description = x.Description,
            }).FirstOrDefault();
            return leavePolicy;
        }

        public async Task<string> InsertAsync(LeavePolicyViewModel leavePolicyModel)
        {
            string result;
            var leavePolicy = new LeavePolicy();

            var isLeavePolicyID = (await _leavePolicyRepo.GetByIdAsync(x => x.LeavePolicyID == leavePolicy.LeavePolicyID)).Any();
            if (isLeavePolicyID)
            {
                result = "LeavePolicyID Already Exists";
            }
            else
            {
                leavePolicy.CompanyID = leavePolicyModel.CompanyID;
                leavePolicy.Description = leavePolicyModel.Description;
                leavePolicy.CreatedTS = DateTime.Now;
                leavePolicy.CreatedBy = leavePolicyModel.CreatedBy;

                await _leavePolicyRepo.InsertAsync(leavePolicy);
                await _leavePolicyRepo.SaveChangesAsync();
                result = "Added Successfully!";
            }

            return result;
        }

        public async Task<LeavePolicyViewModel> UpdateAsync(LeavePolicyViewModel leavePolicyModel)
        {
            var leavePolicyExist = (await _leavePolicyRepo.GetByIdAsync(x => x.LeavePolicyID == leavePolicyModel.LeavePolicyID)).FirstOrDefault();
            if (leavePolicyExist != null)
            {

                leavePolicyExist.CompanyID = leavePolicyModel.CompanyID;
                leavePolicyExist.Description = leavePolicyModel.Description;
             
                await _leavePolicyRepo.UpdateAsync(leavePolicyExist);
                await _leavePolicyRepo.SaveChangesAsync();
            }
            return leavePolicyModel;
        }
    }
}
