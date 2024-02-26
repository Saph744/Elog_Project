using eLog.Service.LeavePolicyService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavePolicyController : ControllerBase
    {
        private readonly ILeavePolicyService _leavePolicyService;
        public LeavePolicyController(ILeavePolicyService leavePolicyService)
        {
            _leavePolicyService = leavePolicyService;
        }

        [HttpPost(nameof(InsertLeavePolicy))]
        public async Task<IActionResult> InsertLeavePolicy(LeavePolicyViewModel leavePolicyModel)
        {
            string result = await _leavePolicyService.InsertAsync(leavePolicyModel);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllLeavePolicy))]
        public async Task<IActionResult> GetAllLeavePolicy()
        {
            var result = await _leavePolicyService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLeavePolicyByID))]
        public async Task<IActionResult> GetLeavePolicyByID(int leavePolicyID)
        {
            var result = await _leavePolicyService.GetByIdAsync(leavePolicyID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateLeavePolicy))]
        public async Task<IActionResult> UpdateLeavePolicy(LeavePolicyViewModel leavePolicyModel)
        {
            await _leavePolicyService.UpdateAsync(leavePolicyModel);
            return Ok("Updation Done");
        }


        [HttpDelete(nameof(DeleteLeavePolicy))]
        public async Task<IActionResult> DeleteLeavePolicy(int leavePolicyID)
        {
            await _leavePolicyService.DeleteAsync(leavePolicyID);
            return Ok("Data deleted");
        }
    }
}

