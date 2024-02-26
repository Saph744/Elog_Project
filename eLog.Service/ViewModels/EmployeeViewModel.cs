using eLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service.ViewModel
{
    public class EmployeeViewModel 
    {
        public int EmployeeID { get; set; }
        public int ContactID { get; set; }
        public int CompanyID { get; set; }
        public string Designation { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentID { get; set; }
        public int EmployeeTypeID { get; set; }
        public int? WorkingDayID { get; set; }
        public int? LeavePolicyID { get; set; }
        public string PermanentAccountNumber { get; set; }
        public string CitizenshipNumber { get; set; }
        public int? LocationID { get; set; }
        public int? LeaveApprovalByID { get; set; }
        public int? HolidayDetailID { get; set; }

        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeTypes { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }

        public int ManagerID { get; set; }
    }
}