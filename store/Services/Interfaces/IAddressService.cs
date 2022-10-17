﻿using storeDTO.Account;
using storeDTO.Address;

namespace store.Services.Interfaces
{
    public interface IAddressService
    {
        public Task<AddDTO> CreateAddressAsync(AddDTO address);
        public Task UpdateAddressAsync(UpdateAddressDTO address);
        public Task DeleteAddressAsync(int id);
        public Task<List<AddressDTO>> GetAllAsync();
        public Task<AddressDTO> GetAddressByIdAsync(int id);
    }
}
