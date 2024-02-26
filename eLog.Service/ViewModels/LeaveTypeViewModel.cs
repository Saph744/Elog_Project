namespace eLog.Service.ViewModels
{
    public class LeaveTypeViewModel
    {
        public int LeaveTypeID { get; set; }

        public int CompanyID { get; set; }

        public String Description { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTS { get; set; }
    }
}
