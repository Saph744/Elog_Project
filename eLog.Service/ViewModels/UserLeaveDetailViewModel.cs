namespace eLog.Service.ViewModels
{
    public class UserLeaveDetailViewModel
    {
        public int UserLeaveID { get; set; }

        public int EmployeeID { get; set; }

        public int CompanyID { get; set; }

        public int LeaveTypeID { get; set; }

        public int YTDEarned { get; set; }

        public int YTDConsumed { get; set; }

        public int PendingApproval { get; set; }

        public int BalanceAvailable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTS { get; set; }

        public string Description { get; set; }

    }
}
