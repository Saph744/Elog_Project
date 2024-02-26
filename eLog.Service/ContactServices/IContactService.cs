using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModel;

namespace eLog.Service
{
    public interface IContactService : IService
    {
        Task<IEnumerable<ContactViewModel>> GetAllAsync();
        Task<ContactViewModel> GetByIdAsync(int Id);
        Task<string> InsertAsync(ContactViewModel viewContact);
        Task<ContactViewModel> UpdateAsync(ContactViewModel viewContact);
        Task<ContactViewModel> DeleteAsync(int Id);
    }
}
