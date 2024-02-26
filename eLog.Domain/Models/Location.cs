namespace eLog.Domain.Models
{
    public class Location : BaseEntity
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int CompanyID { get; set; }
    }
}
