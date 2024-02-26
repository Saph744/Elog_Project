using eLog.Service.ProjectService;
using eLog.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eLog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectservice;
        public ProjectController(IProjectService projectservice)
        {
            _projectservice = projectservice;
        }

        [HttpGet(nameof(GetProject))]
        public async Task<IActionResult> GetProject(int Id)
        {
            var result = await _projectservice.GetProjectAsync(Id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetAllProject))]
        public async Task<IActionResult> GetAllProject()
        {
            var result = await _projectservice.GetAllProjectAsync().ConfigureAwait(false);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpPost(nameof(InsertProject))]
        public async Task<IActionResult> InsertProject(ProjectViewModel project)
        {
            await _projectservice.InsertProjectAsync(project);
            return Ok("Data Inserted SuccessFully");
        }
        [HttpPut(nameof(UpdateProject))]
        public async Task<IActionResult> UpdateProject(ProjectViewModel project)
        {
            await _projectservice.UpdateProjectAsync(project);
            return Ok("Data Updated Successfully");
        }
        [HttpDelete(nameof(DeleteProject))]
        public async Task<IActionResult> DeleteProject(int Id)
        {
            await _projectservice.DeleteProjectAsync(Id);
            return Ok("Data Deleted Successfully");
        }
    }
}
