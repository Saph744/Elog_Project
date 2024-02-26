namespace eLog.Domain.Models
{
    public class Contact : BaseEntity
    {
        public int ContactID { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}
