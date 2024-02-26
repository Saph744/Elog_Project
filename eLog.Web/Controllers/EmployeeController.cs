using eLog.Domain.Models;
using eLog.Service;
using eLog.Service.ViewModel;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IContactService _contactService;

        public EmployeeController(IEmployeeService employeeService, IContactService contactService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
            _contactService = contactService;
        }

        [HttpPost(nameof(InsertEmployee))]
        public async Task<IActionResult> InsertEmployee(EmployeeViewModel viewEmployee)
        {
            string result = await _employeeService.InsertAsync(viewEmployee);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }

     /*   [HttpPost(nameof(InsertData))]
        public async Task<IActionResult> InsertData(EmployeeManagerViewModel viewModel)
        {
            string result = await _employeeService.InsertDataAsync(viewModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }*/

      /*  [HttpGet(nameof(GetAllData))]
        public async Task<IActionResult> GetAllData()
        {
            var result = await _employeeService.GetDataAsync();
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest("No Records Founds");
        }*/

        [HttpGet(nameof(GetAllEmployee))]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _employeeService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetEmployeeByID))]
        public async Task<IActionResult> GetEmployeeByID(int Id)
        {
            var result = await _employeeService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateEmployee))]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel viewEmployee)
        {
            await _employeeService.UpdateAsync(viewEmployee);
            return Ok("Updation Done");
        }

        [HttpDelete(nameof(DeleteEmployee))]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            await _employeeService.DeleteAsync(Id);
            return Ok("Data deleted");
        }

        [HttpPost(nameof(UploadFiles))]
        public async Task<IActionResult> UploadFiles(string a)
        {
            // bool Result = false;
            var FilePath = "";
            try
            {
                var keys = Request.Form.Keys.ToArray();
                var value = "";
                for (int i = 0; i < keys.Length; i++)
                {
                    // here you get the name eg test[0].quantity
                    // keys[i];
                    // to get the value you use
                    value = Request.Form[keys[i]];
                }
            }
            catch (Exception ex)
            {
                var t = ex;
            }
            var Files = Request.Form.Files;
            foreach (IFormFile source in Files)
            {
                string FileName = source.FileName;
                string imagepath = GetActualpath(FileName);
                try
                {
                    if (!Directory.Exists(imagepath))
                        Directory.CreateDirectory(imagepath);
                    //setting the image file path
                    FilePath = imagepath + "\\1.jfif";

                    using (FileStream stream = System.IO.File.Create(FilePath))
                    {
                        await source.CopyToAsync(stream);
                    }

                    //  var contact = new ContactViewModel();
                    var result = await _contactService.GetByIdAsync(Int32.Parse(FileName));

                    if (result != null)
                    {
                        result.FilePath = FilePath;
                        result.FileName = FileName + "_" + "ProfilePic" + "." + "png";
                        result.ContactID = Int32.Parse(FileName);
                        await _contactService.UpdateAsync(result);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Ok(FilePath);
        }

        [NonAction]
        public string GetActualpath(string FileName)
        {
            return _webHostEnvironment.WebRootPath + "\\Uploads\\ProfilePic\\" + FileName;
        }
    }
}