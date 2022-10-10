using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Repo.Interfaces;
using System.Security.Principal;

namespace store.Repo
{
    public class AddressRepository : IAdressRepository
    {
        private readonly StoreContext _ctx;
        public AddressRepository(StoreContext ctx)
        {
            _ctx = ctx; 
        }
        public async Task<Address> AddAddressAsync(Address address)
        {
            _ctx.Addresses.Add(address);
            await _ctx.SaveChangesAsync();
            return address;
        }

        public async Task<Address> DeleteAddressAsync(int id)
        {
            var address = await _ctx.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
            if (address == null)
                return null;
            _ctx.Addresses.Remove(address);
            await _ctx.SaveChangesAsync();
            return address;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await _ctx.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
            return address;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _ctx.Addresses.ToListAsync();
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _ctx.Addresses.Update(address);
            await _ctx.SaveChangesAsync();
            return address;
        }
    }
}
