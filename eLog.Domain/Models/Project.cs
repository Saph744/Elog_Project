
namespace eLog.Domain.Models
{
    public class Project:BaseEntity
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CompanyID { get; set; }
    }
}
 