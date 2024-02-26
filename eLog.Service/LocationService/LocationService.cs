using eLog.Domain.Models;
using eLog.Repository;
using eLog.Service.ViewModels;

namespace eLog.Service
{
    public class LocationService : ILocationService
    {
        private IRepository<Location> _locationRepository;
        private IDapperRepository _applicationReadDbConnection;
        public LocationService(IRepository<Location> repository, IDapperRepository applicationReadDbConnection)
        {
            _locationRepository = repository;
            _applicationReadDbConnection = applicationReadDbConnection;
        }
        public async Task<LocationViewModel> DeleteAsync(int Id)
        {
            var isLocationExist = (await _locationRepository.GetByIdAsync(x => x.LocationID == Id)).FirstOrDefault();
            if (isLocationExist != null)
            {
                await _locationRepository.DeleteAsync(isLocationExist);
                await _locationRepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllAsync()
        {
            var query = $"SELECT * FROM Location";
            var location = await _applicationReadDbConnection.QueryAsync<LocationViewModel>(query);
            return location.ToList();
        }

        public async Task<LocationViewModel> GetByIdAsync(int Id)
        {
            var result = await _locationRepository.GetByIdAsync(x => x.LocationID == Id);
            var location = result.Select(x => new LocationViewModel
            {
                LocationID = x.LocationID,
                LocationName = x.LocationName,
                CompanyID = x.CompanyID,
                CreatedBy = x.CreatedBy,
                CreatedTS = x.CreatedTS,
            }).FirstOrDefault();
            return location;
        }

        public async Task<string> InsertAsync(LocationViewModel viewLocation)
        {
            string result;
            var location = new Location();

            var isLocationIDExist = (await _locationRepository.GetByIdAsync(x => x.LocationID == viewLocation.LocationID)).Any();
            if (isLocationIDExist)
            {
                result = "Location Already Exist";
            }
            else
            {
                location.LocationID = viewLocation.LocationID;
                location.LocationName = viewLocation.LocationName;
                location.CompanyID = viewLocation.CompanyID;
                location.CreatedBy = viewLocation.CreatedBy;
                location.CreatedTS = viewLocation.CreatedTS;

                await _locationRepository.InsertAsync(location);
                await _locationRepository.SaveChangesAsync();
                result = "Added Successfully!";
            }
            return result;
        }

        public async Task<LocationViewModel> UpdateAsync(LocationViewModel viewLocation)
        {
            var doesLocationExist = (await _locationRepository.GetByIdAsync(x => x.LocationID == viewLocation.LocationID)).FirstOrDefault();
            if (doesLocationExist != null)
            {
                doesLocationExist.LocationID = viewLocation.LocationID;
                doesLocationExist.LocationName = viewLocation.LocationName;
                doesLocationExist.CompanyID = viewLocation.CompanyID;
                doesLocationExist.CreatedBy = viewLocation.CreatedBy;
                doesLocationExist.CreatedTS = viewLocation.CreatedTS;

                await _locationRepository.UpdateAsync(doesLocationExist);
                await _locationRepository.SaveChangesAsync();
            }
            return viewLocation;
        }
    }
}