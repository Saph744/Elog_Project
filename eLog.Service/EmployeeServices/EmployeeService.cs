using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModel;

namespace eLog.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository;
        private IDapperRepository _applicationReadDbConnection;

        private IRepository<Contact> _contactRepository;
        public EmployeeService(IRepository<Employee> EmployeeRepository, IDapperRepository applicationReadDbConnection, IRepository<Contact> contactRepository)
        {
            _employeeRepository = EmployeeRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
            _contactRepository = contactRepository;
        }
        public async Task<EmployeeViewModel> DeleteAsync(int Id)
        {
            // var employeeList = await _employeeRepository.GetByIdAsync(x => x.EmployeeID == Id);
            var EmployeeDetails = (await _employeeRepository.GetByIdAsync(x => x.ContactID == Id)).FirstOrDefault();
            var ContactDetails = (await _contactRepository.GetByIdAsync(x => x.ContactID == Id)).FirstOrDefault();
            if (EmployeeDetails != null)
            {
                await _employeeRepository.DeleteAsync(EmployeeDetails);
            }
            if (ContactDetails != null)
            {
                await _contactRepository.DeleteAsync(ContactDetails);
            }
            return null;

        }
        public async Task<IEnumerable<EmployeeViewModel>> GetAllAsync()
        {
            var query = $" SELECT EmployeeID,Contact.ContactID,FirstName, MiddleName,LastName,EmailAddress,Address1,Designation,JoinedDate,DepartmentName,DateOfBirth" +
                $" FROM Employee " +
                $"LEFT JOIN Contact ON Employee.ContactID = Contact.ContactID" +
                $" LEFT JOIN Department ON Employee.DepartmentID = Department.DepartmentID";
            var employee = await _applicationReadDbConnection.QueryAsync<EmployeeViewModel>(query);
            return employee.ToList();
        }
        public async Task<EmployeeViewModel> GetByIdAsync(int Id)
        {
            var query = @" SELECT EmployeeID,Employee.DepartmentID,Employee.ContactID,Employee.CompanyID,Employee.EmployeeTypeID,Employee.LeavePolicyID,Employee.LocationID,FirstName, MiddleName,LastName,Contact.EmailAddress,Address1,Address2,Designation,ContactNumber,Gender,DepartmentName,EmployeeTypes,DateOfBirth,JoinedDate,Description,LocationName,Country,State,FileName,FilePath
                            FROM Employee 
                            LEFT JOIN Contact ON Employee.ContactID = Contact.ContactID 
                            LEFT JOIN Department ON Employee.DepartmentID = Department.DepartmentID 
                            LEFT JOIN EmployeeType ON Employee.EmployeeTypeID = EmployeeType.EmployeeTypeID 
                            LEFT JOIN LeavePolicy ON Employee.LeavePolicyID = LeavePolicy.LeavePolicyID 
                            LEFT JOIN Location ON Employee.LocationID = Location.LocationID  
                            LEFT JOIN Company ON Employee.CompanyID = Company.CompanyID  
                            WHERE EmployeeID=@EmployeeID ";
            var sqlParameter = new { EmployeeID = Id };
            var employee = await _applicationReadDbConnection.QueryAsync<EmployeeViewModel>(query, sqlParameter);

            return employee.FirstOrDefault();

        }
       /* public async Task<IEnumerable<EmployeeViewModel>> GetDataAsync()
        {
            var  query = $" SELECT EmployeeID,Designation FROM Employee INNER JOIN Contact ON Contact.ContactID = Employee.ContactID WHERE Employee.Designation = 'Manager'";
            var employeemanager = await _applicationReadDbConnection.QueryAsync<EmployeeViewModel>(query);
            return employeemanager.ToList();
        }*/

      /*  public async Task<string> InsertDataAsync(EmployeeManagerViewModel viewModel)
        {
            string result;
            var employeeManager = new EmployeeManagers()
            {

            }

           }*/
        public async Task<string> InsertAsync(EmployeeViewModel viewEmployee)
        {
            string result;
            var contactDetails = new Contact()
            {
                CompanyID = viewEmployee.CompanyID,
                FirstName = viewEmployee.Firstname,
                MiddleName = viewEmployee.MiddleName,
                LastName = viewEmployee.Lastname,
                Address1 = viewEmployee.Address1,
                Address2 = viewEmployee.Address2,
                ContactNumber = viewEmployee.ContactNumber,
                EmailAddress = viewEmployee.EmailAddress,
                DateOfBirth = viewEmployee.DateOfBirth,
                Gender = viewEmployee.Gender,
                CreatedTS = DateTime.Now,
            };
            await _contactRepository.InsertAsync(contactDetails);
            await _contactRepository.SaveChangesAsync();

            var employeeDetails = new Employee()
            {
                ContactID = contactDetails.ContactID,
                CompanyID = viewEmployee.CompanyID,
                Designation = viewEmployee.Designation,
                JoinedDate = viewEmployee.JoinedDate,
                IsActive = viewEmployee.IsActive,
                DepartmentID = viewEmployee.DepartmentID,
                EmployeeTypeID = viewEmployee.EmployeeTypeID,
                WorkingDayID = viewEmployee.WorkingDayID,
                LeavePolicyID = viewEmployee.LeavePolicyID,
                PermanentAccountNumber = viewEmployee.PermanentAccountNumber,
                CitizenshipNumber = viewEmployee.CitizenshipNumber,
                LocationID = viewEmployee.LocationID,
                LeaveApprovalByID = viewEmployee.LeaveApprovalByID,
                HolidayDetailID = viewEmployee.HolidayDetailID,
                CreatedTS = DateTime.Now,
            };
            await _employeeRepository.InsertAsync(employeeDetails);
            await _employeeRepository.SaveChangesAsync();
            result = "Added data successfully";

            return result;
        }
        public async Task<EmployeeViewModel> UpdateAsync(EmployeeViewModel viewEmployee)
        {
            var ContactDetails = (await _contactRepository.GetByIdAsync(e => e.ContactID == viewEmployee.ContactID)).FirstOrDefault();
            if (ContactDetails != null)
            {
                ContactDetails.FirstName = viewEmployee.Firstname;
                ContactDetails.MiddleName = viewEmployee.MiddleName;
                ContactDetails.LastName = viewEmployee.Lastname;
                ContactDetails.Address1 = viewEmployee.Address1;
                ContactDetails.Address2 = viewEmployee.Address2;
                ContactDetails.ContactNumber = viewEmployee.ContactNumber;
                ContactDetails.EmailAddress = viewEmployee.EmailAddress;
                ContactDetails.FileName = viewEmployee.FileName;
                ContactDetails.FilePath = viewEmployee.FilePath;

                await _contactRepository.UpdateAsync(ContactDetails);
            }

            var EmployeeDetails = (await _employeeRepository.GetByIdAsync(e => e.EmployeeID == viewEmployee.EmployeeID)).FirstOrDefault();
            if (EmployeeDetails != null)
            {
                EmployeeDetails.CompanyID = viewEmployee.CompanyID;
                EmployeeDetails.ContactID = viewEmployee.ContactID;
                EmployeeDetails.Designation = viewEmployee.Designation;
                EmployeeDetails.JoinedDate = viewEmployee.JoinedDate;
                EmployeeDetails.IsActive = viewEmployee.IsActive;
                EmployeeDetails.DepartmentID = viewEmployee.DepartmentID;
                EmployeeDetails.EmployeeTypeID = viewEmployee.EmployeeTypeID;
                EmployeeDetails.WorkingDayID = viewEmployee.WorkingDayID;
                EmployeeDetails.LeavePolicyID = viewEmployee.LeavePolicyID;
                EmployeeDetails.PermanentAccountNumber = viewEmployee.PermanentAccountNumber;
                EmployeeDetails.CitizenshipNumber = viewEmployee.CitizenshipNumber;
                EmployeeDetails.LocationID = viewEmployee.LocationID;
                EmployeeDetails.LeaveApprovalByID = viewEmployee.LeaveApprovalByID;

                await _employeeRepository.UpdateAsync(EmployeeDetails);
            }
            return viewEmployee;
        }
    }
}