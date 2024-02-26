using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost(nameof(InsertRole))]
        public async Task<IActionResult> InsertRole(RoleViewModel roleViewModel)
        {
            string result = await _roleService.InsertRoleAsync(roleViewModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }
        [HttpGet(nameof(GetAllRole))]
        public async Task<IActionResult> GetAllRole()
        {
            var result = await _roleService.GellAllRolesAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetRole))]
        public async Task<IActionResult> GetRole(int RoleID)
        {
            var result = await _roleService.GetRoleAsync(RoleID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateRole))]
        public async Task<IActionResult> UpdateRole(RoleViewModel roleViewModel)
        {
            await _roleService.UpdateRoleAsync(roleViewModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteCompany))]
        public async Task<IActionResult> DeleteCompany(int CompanyID)
        {
            await _roleService.DeleteRoleAsync(CompanyID);
            return Ok("Data deleted");
        }
    }
}
