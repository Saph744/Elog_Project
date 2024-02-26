using eLog.Service;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(ICompanyService companyService, IWebHostEnvironment webHostEnvironment)
        {
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost(nameof(InsertCompany))]
        public async Task<IActionResult> InsertCompany(CompanyViewModel companyViewModel)
        {
            string result = await _companyService.InsertCompanyAsync(companyViewModel);
            if (result != null)
            {

                return Ok("Data Inserted");
            }
            return BadRequest(new { result = "Unable to insert data" });
        }
        [HttpGet(nameof(GetAllCompany))]
        public async Task<IActionResult> GetAllCompany()
        {
            var result = await _companyService.GellAllCompanysAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetCompany))]
        public async Task<IActionResult> GetCompany(int CompanyID)
        {
            var result = await _companyService.GetCompanyAsync(CompanyID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPut(nameof(UpdateCompany))]
        public async Task<IActionResult> UpdateCompany(CompanyViewModel companyViewModel)
        {
            await _companyService.UpdateCompanyAsync(companyViewModel);
            return Ok("Updation Done");
        }

        
        [HttpDelete(nameof(DeleteCompany))]
        public async Task<IActionResult> DeleteCompany(int CompanyID)
        {
            await _companyService.DeleteCompanyAsync(CompanyID);
            return Ok("Data deleted"); 
        }

        [HttpPost(nameof(UploadFiles))]
        public async Task<IActionResult> UploadFiles(string a)
        {
            //  bool Result = false;
           // var path = "//Uploads/Company//";
            var Filepath = "";
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
                string ImageFilePath = GetActualpath(FileName);
                try
                {
                    if (!System.IO.Directory.Exists(ImageFilePath))
                        System.IO.Directory.CreateDirectory(ImageFilePath);

                    Filepath = ImageFilePath + "\\1.png";

                    if (System.IO.File.Exists(Filepath))
                        System.IO.File.Delete(Filepath);

                    using (FileStream stream = System.IO.File.Create(Filepath))
                    {
                        await source.CopyToAsync(stream);
                        
                    }
                    var companyViewModel = new CompanyViewModel();
                    var result = await _companyService.GetCompanyAsync(Int32.Parse(FileName));
                    companyViewModel.ImageFilePath= Filepath;
                    companyViewModel.CompanyID = result.CompanyID;
                    companyViewModel.CompanyName = result.CompanyName;
                    companyViewModel.PhoneNumber = result.PhoneNumber;
                    companyViewModel.Website = result.Website;
                    companyViewModel.Country = result.Country;
                    companyViewModel.EmailAddress = result.EmailAddress;
                    companyViewModel.ImageName = result.ImageName;
                    companyViewModel.Address = result.Address;              
                    companyViewModel.CreatedBy = result.CreatedBy;              
                    companyViewModel.City = result.City;
                    companyViewModel.CountryCode = result.CountryCode;
                    companyViewModel.State = result.State;
                    companyViewModel.CompanyAbbreviation = result.CompanyAbbreviation;
                    companyViewModel.FaxNumber = result.FaxNumber;          

                    //companyViewModel.CompanyID = FileResult;
                    await _companyService.UpdateCompanyAsync(companyViewModel);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Ok(Filepath);

        }
        [NonAction]
        public string GetActualpath(string FileName)
        {
            return _webHostEnvironment.WebRootPath + "\\Uploads\\Company\\" + FileName;
        }
    }
}
