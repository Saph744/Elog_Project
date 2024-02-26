using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.LeavePolicySettingService
{
    public class LeavePolicySettingService : ILeavePolicySettingService
    {
        private readonly IRepository<LeavePolicySetting> _leavePolicySettingRepo;
        private readonly IDapperRepository _applicationReadDbConnection;
        public LeavePolicySettingService(IRepository<LeavePolicySetting> leavePolicySettingRepo,IDapperRepository applicationReadDbConnection)
        {
            _leavePolicySettingRepo = leavePolicySettingRepo;
            _applicationReadDbConnection = applicationReadDbConnection;
        }

        public async Task<LeavePolicySettingViewModel> DeleteAsync(int leavePolicySettingID)
        {
            var result = (await _leavePolicySettingRepo.GetByIdAsync(x => x.LeavePolicySettingID == leavePolicySettingID)).FirstOrDefault();
            if (result != null)
            {
                await _leavePolicySettingRepo.DeleteAsync(result);
                await _leavePolicySettingRepo.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IList<LeavePolicySettingViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM LeavePolicySetting";
            var leavePolicySetting = await _applicationReadDbConnection.QueryAsync<LeavePolicySettingViewModel>(query);
            return leavePolicySetting.ToList();
        }

        public async Task<LeavePolicySettingViewModel> GetByIdAsync(int leavePolicySettingID)
        {
            var result = await _leavePolicySettingRepo.GetByIdAsync(x => x.LeavePolicySettingID == leavePolicySettingID);
            var leavePolicySetting = result.Select(x => new LeavePolicySettingViewModel
            {
                LeavePolicySettingID = x.LeavePolicySettingID,
                CompanyID = x.CompanyID,
                LeaveTypeID = x.LeaveTypeID,
                EffectiveDate = x.EffectiveDate,
                InitialBalance = x.InitialBalance,
                EarnDays = x.EarnDays,
                EarnPeriodID = x.EarnPeriodID,
                ResetAtID = x.ResetAtID,
                ResetDays = x.ResetDays,
                MaxAvailableDays = x.MaxAvailableDays,
                EnableSandwich = x.EnableSandwich,
                DisableNegativeBalance = x.DisableNegativeBalance,
                SandwichCount = x.SandwichCount,
                IsActive = x.IsActive,
            }).FirstOrDefault();
            return leavePolicySetting;
        }

        public async Task<IList<LeavePolicySettingViewModel>> GetPolicyByIdAsync(int leavePolicyID)
        {
            var query = $"SELECT Description, EffectiveDate,InitialBalance,EarnDays,ResetDays,MaxAvailableDays,EnableSandwich,DisableNegativeBalance,SandwichCount FROM LeavePolicySetting INNER JOIN LeaveType ON LeavePolicySetting.LeaveTypeID = LeaveType.LeaveTypeID WHERE LeavePolicyID = @LeavePolicyID";
            var result = await _applicationReadDbConnection.QueryAsync<LeavePolicySettingViewModel>(query, new { leavePolicyID });
            List<LeavePolicySettingViewModel> policyDetails = result.ToList();
            return policyDetails;
        }

        public async Task<string> InsertAsync(LeavePolicySettingViewModel leavePolicySettingModel)
        {
            string result;
            var leavePolicySetting = new LeavePolicySetting();

            var isLeaveSettingID = (await _leavePolicySettingRepo.GetByIdAsync(x => x.LeaveTypeID == leavePolicySettingModel.LeaveTypeID && x.LeavePolicyID==leavePolicySettingModel.LeavePolicyID)).Any();
            if (isLeaveSettingID)
            {
                result = "LeaveTypeID Already Exists";
            }
            else
            {
                leavePolicySetting.CompanyID = leavePolicySettingModel.CompanyID;
                leavePolicySetting.LeaveTypeID = leavePolicySettingModel.LeaveTypeID;
                leavePolicySetting.EffectiveDate = leavePolicySettingModel.EffectiveDate;
                leavePolicySetting.InitialBalance = leavePolicySettingModel.InitialBalance;
                leavePolicySetting.EarnDays = leavePolicySettingModel.EarnDays;
                leavePolicySetting.EarnPeriodID = leavePolicySettingModel.EarnPeriodID;
                leavePolicySetting.ResetAtID = leavePolicySettingModel.ResetAtID;
                leavePolicySetting.ResetDays = leavePolicySettingModel.ResetDays;
                leavePolicySetting.MaxAvailableDays = leavePolicySettingModel.MaxAvailableDays;
                leavePolicySetting.EnableSandwich = leavePolicySettingModel.EnableSandwich;
                leavePolicySetting.DisableNegativeBalance = leavePolicySettingModel.DisableNegativeBalance;
                leavePolicySetting.SandwichCount = leavePolicySettingModel.SandwichCount;
                leavePolicySetting.CreatedBy = leavePolicySettingModel.CreatedBy;
                leavePolicySetting.CreatedTS = DateTime.Now;
                leavePolicySetting.IsActive = leavePolicySettingModel.IsActive;
                leavePolicySetting.LeavePolicyID=leavePolicySettingModel.LeavePolicyID;

                await _leavePolicySettingRepo.InsertAsync(leavePolicySetting);
                await _leavePolicySettingRepo.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<LeavePolicySettingViewModel> UpdateAsync(LeavePolicySettingViewModel leavePolicySettingModel)
        {
            var leavePolicySettingExist = (await _leavePolicySettingRepo.GetByIdAsync(x => x.LeavePolicySettingID == leavePolicySettingModel.LeavePolicySettingID)).FirstOrDefault();
            if (leavePolicySettingExist != null)
            {
                leavePolicySettingExist.CompanyID = leavePolicySettingModel.CompanyID;
                leavePolicySettingExist.LeaveTypeID = leavePolicySettingModel.LeaveTypeID;
                leavePolicySettingExist.EffectiveDate = leavePolicySettingModel.EffectiveDate;
                leavePolicySettingExist.InitialBalance = leavePolicySettingModel.InitialBalance;
                leavePolicySettingExist.EarnDays = leavePolicySettingModel.EarnDays;
                leavePolicySettingExist.EarnPeriodID = leavePolicySettingModel.EarnPeriodID;
                leavePolicySettingExist.ResetAtID = leavePolicySettingModel.ResetAtID;
                leavePolicySettingExist.ResetDays = leavePolicySettingModel.ResetDays;
                leavePolicySettingExist.MaxAvailableDays = leavePolicySettingModel.MaxAvailableDays;
                leavePolicySettingExist.EnableSandwich = leavePolicySettingModel.EnableSandwich;
                leavePolicySettingExist.DisableNegativeBalance = leavePolicySettingModel.DisableNegativeBalance;
                leavePolicySettingExist.SandwichCount = leavePolicySettingModel.SandwichCount; 
                leavePolicySettingExist.CreatedBy = leavePolicySettingModel.CreatedBy;
                leavePolicySettingExist.LeavePolicyID = leavePolicySettingModel.LeavePolicyID;

                await _leavePolicySettingRepo.UpdateAsync(leavePolicySettingExist);
                await _leavePolicySettingRepo.SaveChangesAsync();
            }
            return leavePolicySettingModel;
        }
    }
}
