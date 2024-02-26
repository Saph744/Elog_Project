using eLog.Domain.Models;
using eLog.Service.HolidayDetailService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayDetailController : ControllerBase
    {
        private readonly IHolidayDetailService _holidayDetailservice;


        public HolidayDetailController(IHolidayDetailService holidayDetailservice)
        {
            _holidayDetailservice = holidayDetailservice;
        }

        [HttpGet(nameof(GetHolidayDetail))]
        public async  Task<IActionResult> GetHolidayDetail(int Id)
        {
            var result = await _holidayDetailservice.GetHolidayDetailAsync(Id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpGet(nameof(GetAllHoliday))]
        public async Task<IActionResult> GetAllHoliday()
        {
            var result = await _holidayDetailservice.GetAllHolidayAsync().ConfigureAwait(false);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpPost(nameof(InsertHoliday))]
        public async Task<IActionResult> InsertHoliday(HolidayDetailViewModel holidayDetail)
        {
            await _holidayDetailservice.InsertHolidayAsync(holidayDetail);
            return Ok("Data Inserted SuccessFully");
        }

        [HttpPut(nameof(UpdateHoliday))]
        public async Task<IActionResult> UpdateHoliday(HolidayDetailViewModel holidayDetail)
        {
           await _holidayDetailservice.UpdateHolidayAsync(holidayDetail);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(DeleteHoliday))] 

        public async Task<IActionResult> DeleteHoliday(int Id)
        {
            await _holidayDetailservice.DeleteHolidayAsync(Id);
            return Ok("Data Deleted Successfully");
        }

    }
}
