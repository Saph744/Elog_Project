using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _employeeTypeService;

        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            _employeeTypeService = employeeTypeService;
        }

        [HttpPost(nameof(InsertEmployeeType))]
        public async Task<IActionResult> InsertEmployeeType(EmployeeTypeViewModel viewEmployeeType)
        {
            string result = await _employeeTypeService.InsertAsync(viewEmployeeType);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllEmployeeType))]
        public async Task<IActionResult> GetAllEmployeeType()
        {
            var result = await _employeeTypeService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetEmployeeTypeByID))]
        public async Task<IActionResult> GetEmployeeTypeByID(int Id)
        {
            var result = await _employeeTypeService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateEmployeeType))]
        public async Task<IActionResult> UpdateEmployeeType(EmployeeTypeViewModel viewEmployeeType)
        {
            await _employeeTypeService.UpdateAsync(viewEmployeeType);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteEmployeeType))]
        public async Task<IActionResult> DeleteEmployeeType(int Id)
        {
            await _employeeTypeService.DeleteAsync(Id);
            return Ok("Data deleted");
        }
    }
}
