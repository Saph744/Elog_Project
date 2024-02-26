using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeTableController : ControllerBase
    {
        private readonly ICodeTableService _codeTableService;
        public CodeTableController(ICodeTableService codeTableService)
        {
            _codeTableService = codeTableService;
        }
        [HttpPost(nameof(InsertCodeTable))]
        public async Task<IActionResult> InsertCodeTable(CodeTableViewModel codeTableViewModel)
        {
            string result = await _codeTableService.InsertCodeTableAsync(codeTableViewModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }
        [HttpGet(nameof(GetAllCodeTable))]
        public async Task<IActionResult> GetAllCodeTable()
        {
            var result = await _codeTableService.GellAllCodeTablesAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetCodeTable))]
        public async Task<IActionResult> GetCodeTable(string? ID)
        {
            var result = await _codeTableService.GetCodeTableAsync(ID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpPut(nameof(UpdateCodeTable))]
        public async Task<IActionResult> UpdateCodeTable(CodeTableViewModel codeTableViewModel)
        {
            await _codeTableService.UpdateCodeTableAsync(codeTableViewModel);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteCodeTable))]
        public async Task<IActionResult> DeleteCodeTable(string ID)
        {
            await _codeTableService.DeleteCodeTableAsync(ID);
            return Ok("Data deleted");
        }
    }
}
