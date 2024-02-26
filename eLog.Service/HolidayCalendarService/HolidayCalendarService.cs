using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.HolidayCalendarService
{
    public class HolidayCalendarService : IHolidayCalendarService
    {
        private readonly IRepository<HolidayCalendar> _calendarrepository;
        private IDapperRepository _applicationReadDbConnection;

        public HolidayCalendarService(IRepository<HolidayCalendar> repository, IDapperRepository applicationReadDbConnection)
        {
            _calendarrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection; 
        }
        public async Task<HolidayCalendarViewModel> DeleteCalendarAsync(int Id)
        {
            var isHolidayCalendarExist = (await _calendarrepository.GetByIdAsync(x => x.HolidayCalendarID == Id)).FirstOrDefault();
            if (isHolidayCalendarExist != null)
            {
                await _calendarrepository.DeleteAsync(isHolidayCalendarExist);
                await _calendarrepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<HolidayCalendarViewModel>> GetAllCalendarAsync()
        {
            var query = $"SELECT * FROM HolidayCalendar";
            var calendar = await _applicationReadDbConnection.QueryAsync<HolidayCalendarViewModel>(query);
            return calendar.ToList();


        }
        public async Task<HolidayCalendarViewModel> GetByIdCalendarAsync(int holidayCalendarId)
        {
            var result = await _calendarrepository.GetByIdAsync(h => h.HolidayCalendarID == holidayCalendarId);
            var calendar = result.Select(h => new HolidayCalendarViewModel
            {
                HolidayCalendarID = h.HolidayCalendarID,
                Country = h.Country,
                CompanyID = h.CompanyID,
                CalendarYear = h.CalendarYear,
                CalendarName = h.CalendarName,
            }).FirstOrDefault();
            return calendar;
        }
        public async Task<HolidayCalendarViewModel> InsertCalendarAsync(HolidayCalendarViewModel holidaycalendarviewmodel)
        {
            
            var holidaycalendar = new HolidayCalendar();

            {
                holidaycalendar.CalendarYear = holidaycalendarviewmodel.CalendarYear;
                holidaycalendar.CalendarName = holidaycalendarviewmodel.CalendarName;
                holidaycalendar.Country = holidaycalendarviewmodel.Country;
                holidaycalendar.CompanyID = holidaycalendarviewmodel.CompanyID;
                holidaycalendar.CreatedTS = DateTime.Now;
                await _calendarrepository.InsertAsync(holidaycalendar);
                await _calendarrepository.SaveChangesAsync();
            }
            return holidaycalendarviewmodel;
        }
        public async Task UpdateCalendarAsync(HolidayCalendarViewModel holidaycalendarviewmodel)
        {
            var doesCalendarExist = (await _calendarrepository.GetByIdAsync(h => h.HolidayCalendarID == holidaycalendarviewmodel.HolidayCalendarID)).FirstOrDefault();
            if (doesCalendarExist != null)
            {
                doesCalendarExist.CalendarYear = holidaycalendarviewmodel.CalendarYear;
                doesCalendarExist.CalendarName = holidaycalendarviewmodel.CalendarName;
                doesCalendarExist.Country = holidaycalendarviewmodel.Country;
                doesCalendarExist.CompanyID = holidaycalendarviewmodel.CompanyID;
                await _calendarrepository.UpdateAsync(doesCalendarExist);
                await _calendarrepository.SaveChangesAsync();
            }
        }
    }
}
