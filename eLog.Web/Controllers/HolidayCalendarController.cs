using eLog.Domain.Models;
using eLog.Service.HolidayCalendarService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayCalendarController : ControllerBase
    {

        private readonly IHolidayCalendarService _holidayCalendarService;

        public HolidayCalendarController(IHolidayCalendarService holidayCalendarService)
        {
            _holidayCalendarService = holidayCalendarService;
        }


        [HttpGet(nameof(GetByHolidayCalendarId))]
        public async Task<IActionResult> GetByHolidayCalendarId(int Id)
        {
            var result = await _holidayCalendarService.GetByIdCalendarAsync(Id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpGet(nameof(GetAllHolidayCalendar))]
        public async Task<IActionResult> GetAllHolidayCalendar()
        {
            var result = await _holidayCalendarService.GetAllCalendarAsync();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpPost(nameof(InsertHolidayCalendar))]
        public async Task<IActionResult> InsertHolidayCalendar(HolidayCalendarViewModel holidaycalendarviewmodel)
        {
            await _holidayCalendarService.InsertCalendarAsync(holidaycalendarviewmodel);
            return Ok("Data Inserted SuccessFully");
        }

        [HttpPut(nameof(UpdateHolidayCalendar))]
        public async Task<IActionResult> UpdateHolidayCalendar(HolidayCalendarViewModel holidaycalendarviewmodel)
        {
            await _holidayCalendarService.UpdateCalendarAsync(holidaycalendarviewmodel);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(DeleteHolidayCalendar))]

        public async Task<IActionResult> DeleteHolidayCalendar(int Id)
        {
            await _holidayCalendarService.DeleteCalendarAsync(Id);
            return Ok("Data Deleted Successfully");
        }

    }
}
