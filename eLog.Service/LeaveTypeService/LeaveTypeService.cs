using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;
namespace eLog.Service.LeaveTypeService
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IRepository<LeaveType> _leaveTypeRepository;
        private readonly IDapperRepository _applicationReadDbConnection;
        public LeaveTypeService(IRepository<LeaveType> leaveTypeRepository, IDapperRepository applicationReadDbConnection)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<LeaveTypeViewModel> DeleteAsync(int leaveTypeID)
        {
            var result = (await _leaveTypeRepository.GetByIdAsync(x => x.LeaveTypeID == leaveTypeID)).FirstOrDefault();
            if (result != null)
            {
                await _leaveTypeRepository.DeleteAsync(result);
                await _leaveTypeRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IList<LeaveTypeViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM LeaveType";
            var leaveType = await _applicationReadDbConnection.QueryAsync<LeaveTypeViewModel>(query);
            return leaveType.ToList();
        }

        public async Task<LeaveTypeViewModel> GetByIdAsync(int leaveTypeID)
        {
            var result = await _leaveTypeRepository.GetByIdAsync(x => x.LeaveTypeID == leaveTypeID);
            var leaveType = result.Select(x => new LeaveTypeViewModel
            {
                LeaveTypeID = x.LeaveTypeID,
                CompanyID = x.CompanyID,
                Description = x.Description,
                IsActive=x.IsActive,
            }).FirstOrDefault();
            return leaveType;
        }

        public async Task<string> InsertAsync(LeaveTypeViewModel leaveTypeModel)
        {
            string result;
            var leaveType = new LeaveType();

            var isLeaveTypeID = (await _leaveTypeRepository.GetByIdAsync(x => x.LeaveTypeID == leaveType.LeaveTypeID)).Any();
            if (isLeaveTypeID)
            {
                result = "LeaveType Already Exists";
            }
            else
            {
                leaveType.CompanyID = leaveTypeModel.CompanyID;
                leaveType.Description = leaveTypeModel.Description;
                leaveType.IsActive = leaveTypeModel.IsActive;
                leaveType.CreatedBy = leaveTypeModel.CreatedBy;
                leaveType.CreatedTS = DateTime.Now;

                await _leaveTypeRepository.InsertAsync(leaveType);
                await _leaveTypeRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<LeaveTypeViewModel> UpdateAsync(LeaveTypeViewModel leaveTypeModel)
        {
            var leaveTypeExist = (await _leaveTypeRepository.GetByIdAsync(x => x.LeaveTypeID == leaveTypeModel.LeaveTypeID)).FirstOrDefault();
            if (leaveTypeExist != null)
            {

                leaveTypeExist.CompanyID = leaveTypeModel.CompanyID;
                leaveTypeExist.Description = leaveTypeModel.Description;
                leaveTypeExist.IsActive = leaveTypeModel.IsActive;

                await _leaveTypeRepository.UpdateAsync(leaveTypeExist);
                await _leaveTypeRepository.SaveChangesAsync();
            }
            return leaveTypeModel;
        }
    }
}
