namespace eLog.Domain.Models
{
    public class LeavePolicySetting:BaseEntity
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

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTS { get; set; }

        public bool IsActive { get; set; }

        public int LeavePolicyID { get; set; }
    }
}
