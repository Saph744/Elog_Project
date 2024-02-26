
using eLog.Repository;
using eLog.Service.UserService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        private IDapperRepository _applicationReadDbConnection;
        public UserController(IUserService userservice, IDapperRepository applicationReadDbConnection)
        {
            _userservice = userservice;
            _applicationReadDbConnection = applicationReadDbConnection;
        }

        [HttpGet(nameof(GetUser))]
        public async Task<IActionResult> GetUser(int Id)
        {
            var result = await _userservice.GetUserAsync(Id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpGet(nameof(GetAllUser))]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userservice.GetAllUserAsync().ConfigureAwait(false);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }


        [HttpPost(nameof(InsertUser))]
        public async Task<IActionResult> InsertUser(UserViewModel userViewModel)
        {
            await _userservice.InsertUserAsync(userViewModel);
            return Ok("Data Inserted SuccessFully");
        }

        [HttpPut(nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
        {
            await _userservice.UpdateUserAsync(userViewModel);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete(nameof(DeleteUser))]

        public async Task<IActionResult> DeleteUser(int Id)
        {
            await _userservice.DeleteUserAsync(Id);
            return Ok("Data Deleted Successfully");
        }

        [HttpPost(nameof(LoginUser))]
        public async Task<IActionResult> LoginUser(UserViewModel userViewModel)
        {
            await _userservice.UserLoginAsync(userViewModel);
            return Ok("Login Controller work");
        }
    }
}
