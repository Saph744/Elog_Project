using eLog.Domain.Models;

namespace eLog.Service.ViewModels
{
    public class WorkingDayViewModel: BaseEntity
    {
        public int WorkingDayID { get; set; }
        public int HourPerDay { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CompanyID { get; set; }
        public bool Sun { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
    }
}
