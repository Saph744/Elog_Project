using eLog.Domain.Service;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service.ProjectService
{
    public interface IProjectService:IService
    {
        Task<IEnumerable<ProjectViewModel>> GetAllProjectAsync();
        Task<ProjectViewModel> GetProjectAsync(int projectId);
        Task<ProjectViewModel> InsertProjectAsync(ProjectViewModel projectViewModel);
        Task UpdateProjectAsync(ProjectViewModel projectViewModel);
        Task<ProjectViewModel> DeleteProjectAsync(int Id);

    }
}
