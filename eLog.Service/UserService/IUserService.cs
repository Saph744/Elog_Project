using eLog.Domain.Models;
using eLog.Domain.Service;
using eLog.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Service.UserService
{
    public interface IUserService: IService
    {
        //User Validate(string username, string userpassword);
        Task<IEnumerable<UserViewModel>> GetAllUserAsync();
        Task<UserViewModel> GetUserAsync(int userId);
        Task<string> InsertUserAsync(UserViewModel userViewModel);
        Task UpdateUserAsync(UserViewModel userViewModel);
        Task<UserViewModel> DeleteUserAsync(int Id);

        Task UserLoginAsync(UserViewModel userViewModel);
    }
}
