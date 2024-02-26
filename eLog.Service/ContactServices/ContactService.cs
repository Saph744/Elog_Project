using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModel;

namespace eLog.Service
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> _ContactRepository;
        private IDapperRepository _applicationReadDbConnection;
        public ContactService(IRepository<Contact> ContactRepository, IDapperRepository applicationReadDbConnection)
        {
            _ContactRepository = ContactRepository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<ContactViewModel> DeleteAsync(int Id)
        {
            var ContactDetails = (await _ContactRepository.GetByIdAsync(x => x.ContactID == Id)).FirstOrDefault();
            if (ContactDetails != null)
            {
                await _ContactRepository.DeleteAsync(ContactDetails);
                await _ContactRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM Contact";
            var contact = await _applicationReadDbConnection.QueryAsync<ContactViewModel>(query);
            return contact.ToList();
        }

        public async Task<ContactViewModel> GetByIdAsync(int Id)
        {
            var result = await _ContactRepository.GetByIdAsync(x => x.ContactID == Id);
            var cont = result.Select(x => new ContactViewModel
            {
                ContactID = x.ContactID,
                CompanyID = x.CompanyID,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Address1 = x.Address1,
                Address2 = x.Address2,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                DateOfBirth = (DateTime)x.DateOfBirth,
                Gender = x.Gender,
                FileName = x.FileName,
                FilePath = x.FilePath,

            }).FirstOrDefault();

            return cont;
        }
        public async Task<string> InsertAsync(ContactViewModel viewContact)
        {
            string result;
            var x = new Contact();
            var isContactIdExist = (await _ContactRepository.GetByIdAsync(c => c.ContactID == viewContact.ContactID)).Any();
            if (isContactIdExist)
            {
                result = " contactID  already exist!";
            }
            else
            {
                x.ContactID = viewContact.ContactID;
                x.CompanyID = viewContact.CompanyID;
                x.FirstName = viewContact.FirstName;
                x.MiddleName = viewContact.MiddleName;
                x.LastName = viewContact.LastName;
                x.Address1 = viewContact.Address1;
                x.Address2 = viewContact.Address2;
                x.ContactNumber = viewContact.ContactNumber;
                x.EmailAddress = viewContact.EmailAddress;
                x.DateOfBirth = viewContact.DateOfBirth;
                x.Gender = viewContact.Gender;
                x.FileName = viewContact.FileName;
                x.FilePath = viewContact.FilePath;
                x.CreatedBy = viewContact.CreatedBy;
                x.CreatedTS = viewContact.CreatedTS;


                await _ContactRepository.InsertAsync(x);
                await _ContactRepository.SaveChangesAsync();
                result = "Added data successfully";
            }
            return result;
        }

        public async Task<ContactViewModel> UpdateAsync(ContactViewModel viewContact)
        {

            var ContactExist = (await _ContactRepository.GetByIdAsync(x => x.ContactID == viewContact.ContactID)).FirstOrDefault();
            if (ContactExist != null)
            {
                //ContactExist.ContactID = viewContact.ContactID;
                ContactExist.CompanyID = viewContact.CompanyID;
                ContactExist.FirstName = viewContact.FirstName;
                ContactExist.MiddleName = viewContact.MiddleName;
                ContactExist.LastName = viewContact.LastName;
                ContactExist.Address1 = viewContact.Address1;
                ContactExist.Address2 = viewContact.Address2;
                ContactExist.ContactNumber = viewContact.ContactNumber;
                ContactExist.EmailAddress = viewContact.EmailAddress;
                ContactExist.DateOfBirth = viewContact.DateOfBirth;
                ContactExist.Gender = viewContact.Gender;
                ContactExist.FileName = viewContact.FileName;
                ContactExist.FilePath = viewContact.FilePath;

                await _ContactRepository.UpdateAsync(ContactExist);
                await _ContactRepository.SaveChangesAsync();
            }
            return viewContact;
        }
    }
}