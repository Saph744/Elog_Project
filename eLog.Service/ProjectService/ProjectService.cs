using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectrepository;
        private IDapperRepository _applicationReadDbConnection;
        public ProjectService(IRepository<Project> repository, IDapperRepository applicationReadDbConnection)
        {
            _projectrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }
        public async Task<ProjectViewModel> DeleteProjectAsync(int Id)
        {
            var isProjectExist = (await _projectrepository.GetByIdAsync(x => x.ProjectID == Id)).FirstOrDefault();
            if (isProjectExist != null)
            {
                await _projectrepository.DeleteAsync(isProjectExist);
                await _projectrepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectAsync()
        {
            var query = $"SELECT * FROM Project";
            var detail = await _applicationReadDbConnection.QueryAsync<ProjectViewModel>(query);
            return detail.ToList();
        }
        public async Task<ProjectViewModel> GetProjectAsync(int projectId)
        {
            var result = await _projectrepository.GetByIdAsync(h => h.ProjectID == projectId);
            var project = result.Select(h => new ProjectViewModel
            {
                ProjectID = h.ProjectID,
                CompanyID = h.CompanyID,
                ProjectName = h.ProjectName,
            }).FirstOrDefault();
            return project;
        }
        public async Task<ProjectViewModel> InsertProjectAsync(ProjectViewModel projectViewModel)
        {
            string result;
            var project = new Project();
            var isProjectNameExist = (await _projectrepository.GetByIdAsync(h => h.ProjectName == projectViewModel.ProjectName)).Any();
            if (isProjectNameExist)
            {
                result = "Project Name already exist!";
            }
            else
            {
                project.CompanyID = projectViewModel.CompanyID;
                project.ProjectName = projectViewModel.ProjectName;
                project.CreatedTS = DateTime.Now;
                await _projectrepository.InsertAsync(project);
                await _projectrepository.SaveChangesAsync();
                result = "Added data Successfully";
            }
            return projectViewModel;
        }

        public async Task UpdateProjectAsync(ProjectViewModel projectViewModel)
        {
            var doesProjectExist = (await _projectrepository.GetByIdAsync(h => h.ProjectID == projectViewModel.ProjectID)).FirstOrDefault();
            if (doesProjectExist != null)
            {
                doesProjectExist.ProjectID = projectViewModel.ProjectID;
                doesProjectExist.CompanyID = projectViewModel.CompanyID;
                doesProjectExist.ProjectName = projectViewModel.ProjectName;
                await _projectrepository.UpdateAsync(doesProjectExist);
                await _projectrepository.SaveChangesAsync();
            }
        }
    }
}
