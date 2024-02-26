using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost(nameof(InsertLocation))]
        public async Task<IActionResult> InsertLocation(LocationViewModel viewLocation)
        {
            string result = await _locationService.InsertAsync(viewLocation);
            if (result != null)
            {
                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllLocationData))]
        public async Task<IActionResult> GetAllLocationData()
        {
            var result = await _locationService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetLocationByID))]
        public async Task<IActionResult> GetLocationByID(int Id)
        {
            var result = await _locationService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateLocation))]
        public async Task<IActionResult> UpdateLocation(LocationViewModel viewLocation)
        {
            await _locationService.UpdateAsync(viewLocation);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteLocation))]
        public async Task<IActionResult> DeleteLocation(int Id)
        {
            await _locationService.DeleteAsync(Id);
            return Ok("Data deleted");
        }
    }
}