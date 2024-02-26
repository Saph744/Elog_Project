using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Domain.Models
{
    public class HolidayCalendar: BaseEntity
    {
        public int HolidayCalendarID { get; set; }
        public int CompanyID { get; set; }
        public string Country { get; set; }
        public string CalendarYear { get; set; }
        public string CalendarName { get; set; }
      
    }
}
