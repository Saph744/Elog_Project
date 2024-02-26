using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDayController : ControllerBase
    {
        private readonly IWorkingDayService _workingDayService;

        public WorkingDayController(IWorkingDayService workingDayService)
        {
            _workingDayService = workingDayService;
        }
        [HttpPost(nameof(InsertWorkingDay))]
        public async Task<IActionResult> InsertWorkingDay(WorkingDayViewModel workingDayViewModel)
        {
            string result = await _workingDayService.InsertWorkingDayAsync(workingDayViewModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }
        [HttpGet(nameof(GetAllWorkingDay))]
        public async Task<IActionResult> GetAllWorkingDay()
        {
            var result = await _workingDayService.GellAllWorkingDaysAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetWorkingDay))]
        public async Task<IActionResult> GetWorkingDay(int WorkingDayID)
        {
            var result = await _workingDayService.GetWorkingDayAsync(WorkingDayID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateWorkingDay))]
        public async Task<IActionResult> UpdateWorkingDay(WorkingDayViewModel workingDayViewModel)
        {
            await _workingDayService.UpdateWorkingDayAsync(workingDayViewModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteWorkingDay))]
        public async Task<IActionResult> DeleteWorkingDay(int WorkingDayID)
        {
            await _workingDayService.DeleteWorkingDayAsync(WorkingDayID);
            return Ok("Data deleted");
        }
    }
}
