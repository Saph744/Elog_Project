using eLog.Domain.Service;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public interface ICodeTableService:IService
    {
        Task<IEnumerable<CodeTableViewModel>> GellAllCodeTablesAsync();
        Task<CodeTableViewModel> GetCodeTableAsync(string ID);
        Task<string> InsertCodeTableAsync(CodeTableViewModel codeTableViewModel);
        Task<CodeTableViewModel> UpdateCodeTableAsync(CodeTableViewModel codeTableViewModel);
        Task<CodeTableViewModel> DeleteCodeTableAsync(string ID);
    }
}
