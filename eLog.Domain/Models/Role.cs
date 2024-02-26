using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Models
{
    public class Role:BaseEntity
    {
        public int RoleID { get; set; }
        public string RoleType { get; set; }
        public int CompanyID { get; set; }
    }
}
