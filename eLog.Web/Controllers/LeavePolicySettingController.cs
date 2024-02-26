using eLog.Service.LeavePolicySettingService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavePolicySettingController : ControllerBase
    {
        private readonly ILeavePolicySettingService _leavePolicySettingService;
        public LeavePolicySettingController(ILeavePolicySettingService leavePolicySettingService)
        {
            _leavePolicySettingService = leavePolicySettingService;
        }

        [HttpPost(nameof(InsertLeaveSetting))]
        public async Task<IActionResult> InsertLeaveSetting(LeavePolicySettingViewModel leavePolicySettingModel)
        {
            string result = await _leavePolicySettingService.InsertAsync(leavePolicySettingModel);
            if (result == "LeaveTypeID Already Exists")
            {
                return Ok("Cannot Insert Same LeaveType for Leave Policy");
            }
            else if(result!=null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllLeaveSetting))]
        public async Task<IActionResult> GetAllLeaveSetting()
        {
            var result = await _leavePolicySettingService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLeaveSettingByID))]
        public async Task<IActionResult> GetLeaveSettingByID(int leavePolicySettingID)
        {
            var result = await _leavePolicySettingService.GetByIdAsync(leavePolicySettingID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLeavePolicyByID))]
        public async Task<IActionResult> GetLeavePolicyByID(int leavePolicyID)
        {
            var result = await _leavePolicySettingService.GetPolicyByIdAsync(leavePolicyID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateLeaveSetting))]
        public async Task<IActionResult> UpdateLeaveSetting(LeavePolicySettingViewModel leavePolicySettingModel)
        {
            await _leavePolicySettingService.UpdateAsync(leavePolicySettingModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteLeaveSetting))]
        public async Task<IActionResult> DeleteLeaveSetting(int leavePolicySettingID)
        {
            await _leavePolicySettingService.DeleteAsync(leavePolicySettingID);
            return Ok("Data deleted");
        }
    }
}
