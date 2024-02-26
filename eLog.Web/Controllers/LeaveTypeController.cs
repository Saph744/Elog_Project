using eLog.Service.LeaveTypeService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        [HttpPost(nameof(InsertLeaveType))]
        public async Task<IActionResult> InsertLeaveType(LeaveTypeViewModel leaveTypeModel)
        {
            string result = await _leaveTypeService.InsertAsync(leaveTypeModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllLeaveType))]
        public async Task<IActionResult> GetAllLeaveType()
        {
            var result = await _leaveTypeService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLeaveTypeByID))]
        public async Task<IActionResult> GetLeaveTypeByID(int leaveTypeID)
        {
            var result = await _leaveTypeService.GetByIdAsync(leaveTypeID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateLeaveType))]
        public async Task<IActionResult> UpdateLeaveType(LeaveTypeViewModel leaveTypeModel)
        {
            await _leaveTypeService.UpdateAsync(leaveTypeModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteLeaveType))]
        public async Task<IActionResult> DeleteLeaveType(int leaveTypeID)
        {
            await _leaveTypeService.DeleteAsync(leaveTypeID);
            return Ok("Data deleted");
        }
    }
}
