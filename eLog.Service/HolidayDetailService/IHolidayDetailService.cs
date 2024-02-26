using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModels;

namespace eLog.Service.HolidayDetailService
{
    public  interface IHolidayDetailService:IService
    {
        Task<IEnumerable<HolidayDetailViewModel>> GetAllHolidayAsync();
        Task<HolidayDetailViewModel> GetHolidayDetailAsync(int holidaydetailId);
        Task<HolidayDetailViewModel> InsertHolidayAsync(HolidayDetailViewModel holidayDetailViewModel);
        Task UpdateHolidayAsync(HolidayDetailViewModel holidayDetailViewModel);
        Task<HolidayDetailViewModel> DeleteHolidayAsync(int Id);
    }
}
