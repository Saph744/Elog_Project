using eLog.Domain.Models;
namespace eLog.Service.ViewModels
{
    public class RoleViewModel:BaseEntity
    {
        public int RoleID { get; set; }
        public string RoleType { get; set; }
        public int CompanyID { get; set; }
    }
}
