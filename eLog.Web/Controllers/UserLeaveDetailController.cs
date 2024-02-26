using eLog.Service.UserLeaveDetailService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLeaveDetailController : ControllerBase
    {
        private readonly IUserLeaveDetailService _userLeaveDetailService;
        public UserLeaveDetailController(IUserLeaveDetailService userDetailLeaveService)
        {
            _userLeaveDetailService = userDetailLeaveService;
        }
        [HttpPost(nameof(InsertUserLeave))]
        public async Task<IActionResult> InsertUserLeave(UserLeaveDetailViewModel userLeaveDetailModel)
        {
            string result = await _userLeaveDetailService.InsertUserLeaveAsync(userLeaveDetailModel);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllUserLeave))]
        public async Task<IActionResult> GetAllUserLeave()
        {
            var result = await _userLeaveDetailService.GetAllUserLeaveAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetUserLeaveByID))]
        public async Task<IActionResult> GetUserLeaveByID(int userLeaveDetailID)
        {
            var result = await _userLeaveDetailService.GetUserLeaveByIDAsync(userLeaveDetailID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateUserLeave))]
        public async Task<IActionResult> UpdateUserLeave(UserLeaveDetailViewModel userLeaveDetailModel)
        {
            await _userLeaveDetailService.UpdateUserLeaveAsync(userLeaveDetailModel);
            return Ok("Updation Done");
        }


        [HttpDelete(nameof(DeleteUserLeave))]
        public async Task<IActionResult> DeleteUserLeave(int userLeaveDetailID)
        {
            await _userLeaveDetailService.DeleteUserLeaveAsync(userLeaveDetailID);
            return Ok("Data deleted");
        }
    }
}
