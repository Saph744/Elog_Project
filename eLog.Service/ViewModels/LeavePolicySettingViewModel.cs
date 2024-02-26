namespace eLog.Service.ViewModels
{
    public class LeavePolicySettingViewModel
    {
        public int LeavePolicySettingID { get; set; }

        public int CompanyID { get; set; }

        public int LeaveTypeID { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int InitialBalance { get; set; }

        public int EarnDays { get; set; }

        public int EarnPeriodID { get; set; }

        public String ResetAtID { get; set; }

        public int ResetDays { get; set; }

        public int MaxAvailableDays { get; set; }

        public bool EnableSandwich { get; set; }

        public bool DisableNegativeBalance { get; set; }

        public int SandwichCount { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedTS { get; set; }

        public bool IsActive { get; set; }

        public int LeavePolicyID { get; set; }

        public String Description { get; set; }
    }
}
