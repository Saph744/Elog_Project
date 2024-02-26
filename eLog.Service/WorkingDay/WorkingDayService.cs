using Dapper;
using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public class WorkingDayService:IWorkingDayService
    {
        private IRepository<WorkingDay> _Workingdayrepository;
        private IDapperRepository _applicationReadDbConnection;
        public WorkingDayService(IRepository<WorkingDay> repository, IDapperRepository applicationReadDbConnection)
        {
            _Workingdayrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }

        public async Task<WorkingDayViewModel> DeleteWorkingDayAsync(int WorkingDayID)
        {
            var isWorkingDayExist = (await _Workingdayrepository.GetByIdAsync(x => x.WorkingDayID == WorkingDayID)).FirstOrDefault();
            if (isWorkingDayExist != null)
            {
                await _Workingdayrepository.DeleteAsync(isWorkingDayExist);
                await _Workingdayrepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<WorkingDayViewModel>> GellAllWorkingDaysAsync()
        {
            var query = $"SELECT * FROM WorkingDay";
            var workingDay = await _applicationReadDbConnection.QueryAsync<WorkingDayViewModel>(query);
            return workingDay.ToList();
        }

        public async Task<WorkingDayViewModel> GetWorkingDayAsync(int WorkingDayID)
        {
            var query = $"SELECT WorkingDayID,CreatedTS,CreatedBy,HourPerDay,Description,IsActive,CompanyID,Sun,Mon,Tue,Wed,Thu,Fri,Sat FROM WorkingDay WHERE WorkingDayID=@WorkingDayID";
            var workingDay= await _applicationReadDbConnection.QueryFirstOrDefaultAsync<WorkingDayViewModel>(query, new {WorkingDayID});
            return workingDay;
            
        }

        public async Task<string> InsertWorkingDayAsync(WorkingDayViewModel workingDayViewmodel)
        {
            string result;
            var workingDay = new WorkingDay();
            workingDay.WorkingDayID = workingDayViewmodel.WorkingDayID;
            workingDay.CreatedTS = DateTime.Now;
            workingDay.CreatedBy = workingDayViewmodel.CreatedBy;
            workingDay.HourPerDay = workingDayViewmodel.HourPerDay;
            workingDay.Description = workingDayViewmodel.Description;
            workingDay.IsActive = workingDayViewmodel.IsActive;
            workingDay.CompanyID = workingDayViewmodel.CompanyID;
            workingDay.Sun = workingDayViewmodel.Sun;
            workingDay.Mon = workingDayViewmodel.Mon;
            workingDay.Tue = workingDayViewmodel.Tue;
            workingDay.Wed = workingDayViewmodel.Wed;
            workingDay.Thu = workingDayViewmodel.Thu;
            workingDay.Fri = workingDayViewmodel.Fri;
            workingDay.Sat = workingDayViewmodel.Sat;
            await _Workingdayrepository.InsertAsync(workingDay);
            await _Workingdayrepository.SaveChangesAsync();
            result = "Added Successfully!";
            return result;
        }

        public async Task<WorkingDayViewModel> UpdateWorkingDayAsync(WorkingDayViewModel workingDayViewmodel)
        {
            var doesWorkingdayExist = (await _Workingdayrepository.GetByIdAsync(x => x.WorkingDayID == workingDayViewmodel.WorkingDayID)).FirstOrDefault();
            if (doesWorkingdayExist != null)
            {
                doesWorkingdayExist.HourPerDay = workingDayViewmodel.HourPerDay;
                doesWorkingdayExist.Description = workingDayViewmodel.Description;  
                doesWorkingdayExist.IsActive = workingDayViewmodel.IsActive;    
                doesWorkingdayExist.CompanyID = workingDayViewmodel.CompanyID;  
                doesWorkingdayExist.Sun = workingDayViewmodel.Sun;
                doesWorkingdayExist.Mon = workingDayViewmodel.Mon;
                doesWorkingdayExist.Tue = workingDayViewmodel.Tue;
                doesWorkingdayExist.Wed = workingDayViewmodel.Wed;
                doesWorkingdayExist.Thu = workingDayViewmodel.Thu;
                doesWorkingdayExist.Fri = workingDayViewmodel.Fri;
                doesWorkingdayExist.Sat = workingDayViewmodel.Sat;
                doesWorkingdayExist.CreatedBy = workingDayViewmodel.CreatedBy;
                doesWorkingdayExist.CreatedTS =workingDayViewmodel.CreatedTS;   
                await _Workingdayrepository.UpdateAsync(doesWorkingdayExist);
                await _Workingdayrepository.SaveChangesAsync();
            }
            return workingDayViewmodel;
        }
    }
}
