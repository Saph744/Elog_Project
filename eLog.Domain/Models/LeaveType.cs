namespace eLog.Domain.Models
{
    public class LeaveType:BaseEntity
    {
        public int LeaveTypeID { get; set; }

        public int CompanyID { get; set; }

        public String Description { get; set; }

        public bool IsActive { get; set; }
    }
}
