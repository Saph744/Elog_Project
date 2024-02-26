namespace eLog.Domain.Models
{
    public class EmployeeType : BaseEntity
    {
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypes { get; set; }
        public int CompanyID { get; set; } 
    }
}
