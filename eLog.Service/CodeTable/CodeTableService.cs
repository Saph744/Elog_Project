using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service
{
    public class CodeTableService:ICodeTableService
    {
        private IRepository<CodeTable> _CodeTablerepository;
        private IDapperRepository _applicationReadDbConnection;
        public CodeTableService(IRepository<CodeTable> repository, IDapperRepository applicationReadDbConnection)
        {
            _CodeTablerepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }
        public async Task<CodeTableViewModel> DeleteCodeTableAsync(string ID)
        {
            var isCodeTableExist = (await _CodeTablerepository.GetByIdAsync(x => x.ID == ID)).FirstOrDefault();
            if (isCodeTableExist != null)
            {
                await _CodeTablerepository.DeleteAsync(isCodeTableExist);
                await _CodeTablerepository.SaveChangesAsync();
            }
            return null;
        }
        public async Task<IEnumerable<CodeTableViewModel>> GellAllCodeTablesAsync()
        {
            var query = $"SELECT Description FROM CodeTable WHERE TableName='EarnPeriod'";
            var codeTable = await _applicationReadDbConnection.QueryAsync<CodeTableViewModel>(query);
            return codeTable.ToList();
        }
        public async Task<CodeTableViewModel> GetCodeTableAsync(string ID)
        {
            var result = await _CodeTablerepository.GetByIdAsync(x => x.ID == ID);
            var codeTable = result.Select(x => new CodeTableViewModel
            {
                ID = x.ID,   
                TableName = x.TableName,    
                Description = x.Description,    
                DisplayOrder = x.DisplayOrder,
                IsActive = x.IsActive,
            }).FirstOrDefault();
               return codeTable;
        }
        public async Task<string> InsertCodeTableAsync(CodeTableViewModel codeTableViewModel)
        {
                string result;
                var codeTable = new CodeTable();
                codeTable.ID = codeTableViewModel.ID;
                codeTable.TableName = codeTableViewModel.TableName; 
                codeTable.Description = codeTableViewModel.Description; 
                codeTable.DisplayOrder = codeTableViewModel.DisplayOrder;
                codeTable.IsActive = codeTableViewModel.IsActive;
                codeTable.CreatedTS = DateTime.Now;
                await _CodeTablerepository.InsertAsync(codeTable);
                await _CodeTablerepository.SaveChangesAsync();
                result = "Added Successfully!";

            return result;
        }
        public async Task<CodeTableViewModel> UpdateCodeTableAsync(CodeTableViewModel codeTableViewModel)
        {
            var doesCodeTableExist = (await _CodeTablerepository.GetByIdAsync(x => x.ID== codeTableViewModel.ID)).FirstOrDefault();
            if (doesCodeTableExist != null)
            {
                doesCodeTableExist.TableName = codeTableViewModel.TableName;
                doesCodeTableExist.Description = codeTableViewModel.Description;
                doesCodeTableExist.DisplayOrder = codeTableViewModel.DisplayOrder;
                doesCodeTableExist.IsActive = codeTableViewModel.IsActive;
                await _CodeTablerepository.UpdateAsync(doesCodeTableExist);
                await _CodeTablerepository.SaveChangesAsync();
            }
            return codeTableViewModel;
        }
    }
}
