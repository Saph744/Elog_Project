﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Models
{
    public class User:BaseEntity
    {
        //public Result result { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int EmployeeID { get; set; }
        public int CompanyID { get; set; }

    }
}
