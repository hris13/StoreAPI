using store.Models;

namespace store.Repo.Interfaces
{
    public interface IAdressRepository
    {
        public Task<Address> AddAddressAsync(Address address);
        public Task<Address> UpdateAddressAsync(Address address);
        public Task<Address> GetAddressByIdAsync(int id);
        public Task<List<Address>> GetAllAddressesAsync();
        public Task<Address> DeleteAddressAsync(int id);
    }
}
