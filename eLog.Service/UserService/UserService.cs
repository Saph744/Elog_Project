using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service.UserService
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _userrepository;
        private IDapperRepository _applicationReadDbConnection;
        public UserService(IRepository<User> repository, IDapperRepository applicationReadDbConnection)
        {
            _userrepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;

        }
        public async Task<UserViewModel> DeleteUserAsync(int Id)
        {
            var isUserExist = (await _userrepository.GetByIdAsync(x => x.UserID == Id)).FirstOrDefault();
            if (isUserExist != null)
            {
                await _userrepository.DeleteAsync(isUserExist);
                await _userrepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUserAsync()
        {
            var query = $"SELECT * FROM [User]";
            var detail = await _applicationReadDbConnection.QueryAsync<UserViewModel>(query);
            return detail.ToList();
        }

        public async Task<UserViewModel> GetUserAsync(int userId)
        {
            var result = await _userrepository.GetByIdAsync(h => h.UserID == userId);
            var user = result.Select(h => new UserViewModel
            {
                UserID = h.UserID,
                UserName = h.UserName,
                UserPassword = h.UserPassword,
                CompanyID = h.CompanyID,
                EmployeeID = h.EmployeeID,
            }).FirstOrDefault();
            return user;
        }

        public async Task<string> InsertUserAsync(UserViewModel userViewModel)
        {
            string result;
            var user = new User();
            var isUserNameExist = (await _userrepository.GetByIdAsync(h => h.UserName == userViewModel.UserName)).Any();
            if (isUserNameExist)
            {
                result = "UserName already exist!";
            }
            else
            {
                user.CompanyID = userViewModel.CompanyID;
                user.UserName = userViewModel.UserName;
                user.UserPassword = userViewModel.UserPassword;
                user.EmployeeID = userViewModel.EmployeeID;
                user.CreatedTS = DateTime.Now;
                await _userrepository.InsertAsync(user);
                await _userrepository.SaveChangesAsync();
                result = "Added data Successfully";
            }
            return result;
        }

        public async Task UpdateUserAsync(UserViewModel userViewModel)
        {
            var doesUserExist = (await _userrepository.GetByIdAsync(h => h.UserID == userViewModel.UserID)).FirstOrDefault();
            if (doesUserExist != null)
            {
                doesUserExist.CompanyID = userViewModel.CompanyID;
                doesUserExist.UserName = userViewModel.UserName;
                doesUserExist.UserPassword = userViewModel.UserPassword;
                doesUserExist.EmployeeID = userViewModel.EmployeeID;

                await _userrepository.UpdateAsync(doesUserExist);
                await _userrepository.SaveChangesAsync();
            }
        }

        public async Task UserLoginAsync(UserViewModel userViewModel)
        {
            var query = $"Select * from [User] where Username ='" + userViewModel.UserName + "' AND UserPassword ='" + userViewModel.UserPassword + "'";
            var login = await _applicationReadDbConnection.QueryAsync<UserViewModel>(query); 
        }

        //public  async Task<UserViewModel> UserLoginAsync(string UserName, string UserPassword)
        //{
        //    //if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword))
        //    //    return null;

        //    var login =await _userrepository.GetByIdAsync(x => x.UserName == UserName);
        //    var userLogin = login.Select(h => new UserViewModel
        //    {

        //        UserName = h.UserName,
        //        UserPassword = h.UserPassword,

        //    }).FirstOrDefault();
        //    return userLogin;
        //}
    }
}
