namespace eLog.Domain.Models
{
    public class Company:BaseEntity
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAbbreviation { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public string ImageFilePath { get; set; }
        public DateTime? ModifiedTS { get; set; }
        public int ModifiedBy { get; set; }
        
    }
}
