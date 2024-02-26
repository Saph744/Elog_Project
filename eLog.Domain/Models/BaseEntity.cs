namespace eLog.Domain.Models
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }
    }
}
