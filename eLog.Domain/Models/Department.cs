using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Models
{
    public class Department : BaseEntity
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int CompanyID { get; set; }
    }
}
