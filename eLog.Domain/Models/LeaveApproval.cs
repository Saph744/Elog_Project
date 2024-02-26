namespace eLog.Domain.Models
{
    public class LeaveApproval:BaseEntity
    {
        public int LeaveApprovalID { get; set; }

        public int CompanyID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal DaysOff { get; set; }

        public decimal HourOff { get; set; }

        public String LeaveReason { get; set; }

        public String ApprovalStatus { get; set; }

        public int NoticePeriod { get; set; }

        public int EmployeeID { get; set; }

        public int LeaveTypeID { get; set; }

        public int LeavePolicyID { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTS { get; set; }
    }
}
