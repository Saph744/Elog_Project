using eLog.Domain.Service;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public interface IWorkingDayService:IService
    {
        Task<IEnumerable<WorkingDayViewModel>> GellAllWorkingDaysAsync();
        Task<WorkingDayViewModel> GetWorkingDayAsync(int WorkingDayID);
        Task<string> InsertWorkingDayAsync(WorkingDayViewModel workingDayViewmodel);
        Task<WorkingDayViewModel> UpdateWorkingDayAsync(WorkingDayViewModel workingDayViewmodel);
        Task<WorkingDayViewModel> DeleteWorkingDayAsync(int WorkingDayID);
    }
}
