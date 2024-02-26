namespace eLog.Domain.Models
{
    public class LeavePolicy:BaseEntity
    {
        public int LeavePolicyID { get; set; }

        public int CompanyID { get; set; }

        public String Description { get; set; }
    }
}
