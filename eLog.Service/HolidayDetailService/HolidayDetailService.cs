using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.HolidayDetailService
{
    public class HolidayDetailService: IHolidayDetailService
    {
        private readonly IRepository<HolidayDetail> _holidayrepository;
        private IDapperRepository _applicationReadDbConnection;
        public HolidayDetailService(IRepository<HolidayDetail> repository, IDapperRepository applicationReadDbConnection)
        {
            _holidayrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }
        public async Task<HolidayDetailViewModel> DeleteHolidayAsync(int Id)
        {
            var isHolidayDetailExist = (await _holidayrepository.GetByIdAsync(x => x.HolidayDetailID == Id)).FirstOrDefault();
            if (isHolidayDetailExist != null)
            {
                await _holidayrepository.DeleteAsync(isHolidayDetailExist);
                await _holidayrepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<HolidayDetailViewModel>> GetAllHolidayAsync()
        {
            var query = $"SELECT * FROM HolidayDetail";
            var detail = await _applicationReadDbConnection.QueryAsync<HolidayDetailViewModel>(query);
            return detail.ToList();
        }
        public async Task<HolidayDetailViewModel> GetHolidayDetailAsync(int holidaydetailId)
        {
            var result = await _holidayrepository.GetByIdAsync(h => h.HolidayDetailID == holidaydetailId);
            var calendar = result.Select(h => new HolidayDetailViewModel
            {
                HolidayDetailID = h.HolidayDetailID,
                CompanyID = h.CompanyID,
                HolidayCalendarID = h.HolidayCalendarID,
                HolidayYear = h.HolidayYear,
                HolidayDate = h.HolidayDate,
                Description = h.Description,
                HolidayName = h.HolidayName,
            }).FirstOrDefault();
            return calendar;
        }
        public async Task<HolidayDetailViewModel> InsertHolidayAsync(HolidayDetailViewModel holidayDetailViewModel)
        {
            string result;
            var holidaydetail = new HolidayDetail();
            var isHolidayYearExist = (await _holidayrepository.GetByIdAsync(h => h.HolidayYear == holidayDetailViewModel.HolidayYear)).Any();
           
            
                holidaydetail.CompanyID = holidayDetailViewModel.CompanyID;
                holidaydetail.HolidayCalendarID = holidayDetailViewModel.HolidayCalendarID;
                holidaydetail.HolidayYear = holidayDetailViewModel.HolidayYear;
                holidaydetail.HolidayName = holidayDetailViewModel.HolidayName;
                holidaydetail.HolidayDate = holidayDetailViewModel.HolidayDate;
                holidaydetail.Description = holidayDetailViewModel.Description; 
                holidaydetail.CreatedTS = DateTime.Now;
                await _holidayrepository.InsertAsync(holidaydetail);
                await _holidayrepository.SaveChangesAsync();
                result = "Added data Successfully";
            
            return holidayDetailViewModel;
        }
        public async Task UpdateHolidayAsync(HolidayDetailViewModel holidayDetailViewModel)
        {
            var doesDetailExist = (await _holidayrepository.GetByIdAsync(h => h.HolidayDetailID == holidayDetailViewModel.HolidayDetailID)).FirstOrDefault();
            if (doesDetailExist != null)
            {
                doesDetailExist.CompanyID = holidayDetailViewModel.CompanyID;
                doesDetailExist.HolidayCalendarID = holidayDetailViewModel.HolidayCalendarID;
                doesDetailExist.HolidayYear = holidayDetailViewModel.HolidayYear;
                doesDetailExist.HolidayName = holidayDetailViewModel.HolidayName;
                doesDetailExist.HolidayDate = holidayDetailViewModel.HolidayDate;
                doesDetailExist.Description = holidayDetailViewModel.Description;

                await _holidayrepository.UpdateAsync(doesDetailExist);
                await _holidayrepository.SaveChangesAsync();
            }
        }
    }
}
