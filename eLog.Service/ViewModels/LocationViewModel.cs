using eLog.Domain.Models;

namespace eLog.Service.ViewModels
{
    public class LocationViewModel : BaseEntity
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int CompanyID { get; set; }
    }

}
 