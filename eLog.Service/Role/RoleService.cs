using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public class RoleService: IRoleService
    {
        private IRepository<Role> _Rolerepository;
        private IDapperRepository _applicationReadDbConnection;
        public RoleService(IRepository<Role> repository, IDapperRepository applicationReadDbConnection)
        {
            _Rolerepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }

        public async Task<RoleViewModel> DeleteRoleAsync(int RoleID)
        {
            var isRoleExist = (await _Rolerepository.GetByIdAsync(x => x.RoleID == RoleID)).FirstOrDefault();
            if (isRoleExist != null)
            {
                await _Rolerepository.DeleteAsync(isRoleExist);
                await _Rolerepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<RoleViewModel>> GellAllRolesAsync()
        {
            var query = $"SELECT * FROM Role";
            var Role = await _applicationReadDbConnection.QueryAsync<RoleViewModel>(query);
            return Role.ToList();
        }

        public async Task<RoleViewModel> GetRoleAsync(int RoleID)
        {
            var result = await _Rolerepository.GetByIdAsync(x => x.RoleID == RoleID);
            var role = result.Select(x => new RoleViewModel
            {
                RoleID = x.RoleID,
                RoleType = x.RoleType,
                CompanyID = x.CompanyID,
                CreatedBy = x.CreatedBy,
                CreatedTS = x.CreatedTS,
            }).FirstOrDefault();
            return role;
        }

        public async Task<string> InsertRoleAsync(RoleViewModel roleViewModel)
        {
            string result;
            var Role = new Role();
            Role.RoleID = roleViewModel.RoleID;
            Role.RoleType = roleViewModel.RoleType;
            Role.CompanyID = roleViewModel.CompanyID;
            Role.CreatedBy = roleViewModel.CreatedBy;
            Role.CreatedTS = DateTime.Now;
            await _Rolerepository.InsertAsync(Role);
            await _Rolerepository.SaveChangesAsync();
            result = "Added Successfully!";

            return result;
        }

        public async Task<RoleViewModel> UpdateRoleAsync(RoleViewModel roleViewModel)
        {
            var doesRoleExist = (await _Rolerepository.GetByIdAsync(x => x.RoleID == roleViewModel.RoleID)).FirstOrDefault();
            if (doesRoleExist != null)
            {
                doesRoleExist.RoleType = roleViewModel.RoleType;
                doesRoleExist.CompanyID = roleViewModel.CompanyID;
                doesRoleExist.CreatedTS = roleViewModel.CreatedTS;
                doesRoleExist.CreatedBy = roleViewModel.CreatedBy;
                await _Rolerepository.UpdateAsync(doesRoleExist);
                await _Rolerepository.SaveChangesAsync();
            }
            return roleViewModel;
        }
    }
}
