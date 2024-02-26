namespace eLog.Service.ViewModels
{
    public class LeavePolicyViewModel
    {
        public int LeavePolicyID { get; set; }

        public int CompanyID { get; set; }

        public String Description { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTS { get; set; }
    }
}
