namespace eLog.Domain.Models
{
    public class Employee : BaseEntity
    {
        public int EmployeeID { get; set; }
        public int ContactID { get; set; }
        public int CompanyID { get; set; }
        public string Designation { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentID { get; set; }
        public int EmployeeTypeID { get; set; }
        public int? WorkingDayID { get; set; }
        public int? LeavePolicyID { get; set; }
        public string? PermanentAccountNumber { get; set; }
        public string? CitizenshipNumber { get; set; }
        public int? LocationID { get; set; }
        public int? LeaveApprovalByID { get; set; }
        public int? HolidayDetailID { get; set; }
        public int? ModifiedBy { get; set; }  
        public DateTime? ModifiedTS { get; set; }    
    }
}
