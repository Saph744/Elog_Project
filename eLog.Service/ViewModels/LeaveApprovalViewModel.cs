namespace eLog.Service.ViewModels
{
    public class LeaveApprovalViewModel
    {
        public int LeaveApprovalID { get; set; }

        public int CompanyID{ get; set; }

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

        public int CreatedBy { get; set; }

        public DateTime CreatedTS { get; set; }

        public String Description { get; set; }

        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        public String LastName { get; set; }

        public int ContactID { get; set; }

        public int EmpID { get; set; }
    }
}
