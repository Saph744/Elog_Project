using eLog.Service;
using eLog.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost(nameof(InsertData))]
        public async Task<IActionResult> InsertData(ContactViewModel viewContact)
        {
            string result = await _contactService.InsertAsync(viewContact);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

        [HttpGet(nameof(GetAllData))]
        public async Task<IActionResult> GetAllData()
        {
            var result = await _contactService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetByID))]
        public async Task<IActionResult> GetByID(int Id)
        {
            var result = await _contactService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateContact))]
        public async Task<IActionResult> UpdateContact(ContactViewModel viewContact)
        {
            await _contactService.UpdateAsync(viewContact);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteContact))]
        public async Task<IActionResult> DeleteContact(int Id)
        {
            await _contactService.DeleteAsync(Id);
            return Ok("Data deleted");
        }
    }
}