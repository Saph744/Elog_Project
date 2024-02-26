using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Models
{
    public class CodeTable:BaseEntity
    {
        public string ID { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
