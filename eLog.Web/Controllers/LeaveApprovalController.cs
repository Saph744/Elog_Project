  using eLog.Service.LeaveAppService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApprovalController : ControllerBase
    {
        private readonly ILeaveApprovalService _leaveappService;
        public LeaveApprovalController(ILeaveApprovalService leaveappService)
        {
            _leaveappService = leaveappService;
        }

        [HttpPost(nameof(InsertLeaveApp))]
        public async Task<IActionResult> InsertLeaveApp(LeaveApprovalViewModel leaveappModel)
        {
            string result = await _leaveappService.InsertAsync(leaveappModel);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpPost(nameof(InsertLeaveRequest))]
        public async Task<IActionResult> InsertLeaveRequest(LeaveApprovalViewModel leaveappModel)
        {
           
            var result = await _leaveappService.GetDataByIdAsync(leaveappModel.ContactID);
            if (result != null)
            {
                leaveappModel.EmpID = result.EmpID;
                string answer = await _leaveappService.InsertRequestAsync(leaveappModel);
                if (answer != null)
                {
                    return Ok("Data Inserted");
                }
                else
                {
                    return BadRequest(new { result = "Unable to insert data" });
                }
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllLeaveApp))]
        public async Task<IActionResult> GetAllLeaveApp()
        {
            var result = await _leaveappService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLeaveAppByID))]
        public async Task<IActionResult> GetLeaveAppByID(int LeaveApprovalID)
        {
            var result = await _leaveappService.GetByIdAsync(LeaveApprovalID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetDataByID))]
        public async Task<IActionResult> GetDataByID(int contactID)
        {
            var result = await _leaveappService.GetDataByIdAsync(contactID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateLeaveApp))]
        public async Task<IActionResult> UpdateLeaveApp(LeaveApprovalViewModel leaveappModel)
        {
            await _leaveappService.UpdateAsync(leaveappModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteLeaveApp))]
        public async Task<IActionResult> DeleteLeaveApp(int LeaveApprovalID)
        {
            await _leaveappService.DeleteAsync(LeaveApprovalID);
            return Ok("Data deleted");
        }  
    }
}
