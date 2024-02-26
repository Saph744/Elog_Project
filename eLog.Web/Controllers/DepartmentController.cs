using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost(nameof(InsertDepartment))]
        public async Task<IActionResult> InsertDepartment(DepartmentViewModel viewDepartment)
        {
            string result = await _departmentService.InsertAsync(viewDepartment);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllDepartmentDetails))]
        public async Task<IActionResult> GetAllDepartmentDetails()
        {
            var result = await _departmentService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetDepartmentByID))]
        public async Task<IActionResult> GetDepartmentByID(int Id)
        {
            var result = await _departmentService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateDepartmentDetails))]
        public async Task<IActionResult> UpdateDepartmentDetails(DepartmentViewModel viewDepartment)
        {
            await _departmentService.UpdateAsync(viewDepartment);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteDepartment))]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            await _departmentService.DeleteAsync(Id);
            return Ok("Data deleted");
        }
    }
}
    

