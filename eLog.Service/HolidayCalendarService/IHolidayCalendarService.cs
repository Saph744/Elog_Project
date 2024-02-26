using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModels;
namespace eLog.Service.HolidayCalendarService
{
    public interface IHolidayCalendarService:IService
    {
        Task<IEnumerable<HolidayCalendarViewModel>> GetAllCalendarAsync();
        Task<HolidayCalendarViewModel> GetByIdCalendarAsync(int holidayCalendarId);
        Task<HolidayCalendarViewModel> InsertCalendarAsync(HolidayCalendarViewModel holidaycalendarviewmodel);
         Task UpdateCalendarAsync(HolidayCalendarViewModel holidaycalendarviewmodel);
        Task<HolidayCalendarViewModel> DeleteCalendarAsync(int Id);
    }
}
