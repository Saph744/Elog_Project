using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service.ViewModels
{
    public class HolidayDetailViewModel
    {
        public int HolidayDetailID { get; set; }
        public int CompanyID { get; set; }

        public int HolidayCalendarID { get; set; }
        public int HolidayYear { get; set; }

        public DateTime HolidayDate { get; set; }

        public string Description { get; set; }

        public string HolidayName { get; set; }

     

    }
}
