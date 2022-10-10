using AutoMapper;
using store.Models;
using store.Repo.Interfaces;
using store.Services.Interfaces;
using storeDTO.Account;
using storeDTO.Address;

namespace store.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAdressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IAdressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressDTO> CreateAddressAsync(AddressDTO address)
        {
            if (address != null)
            {
                Address newAddress = _mapper.Map<Address>(address);
                await _addressRepository.AddAddressAsync(newAddress);
                return address;
            }
            else return null;
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressRepository.DeleteAddressAsync(id);
        }

        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            Address address = await _addressRepository.GetAddressByIdAsync(id);
            AddressDTO add = _mapper.Map<AddressDTO>(address);

            return add;
        }

        public async Task<List<AddressDTO>> GetAllAsync()
        {

            List<Address> list = await _addressRepository.GetAllAddressesAsync();
            List<AddressDTO> newlist = _mapper.Map<List<AddressDTO>>(list);
            return newlist;
        }

        public async Task UpdateAddressAsync(UpdateAddressDTO _address)
        {
            Address address = _mapper.Map<Address>(_address);
            await _addressRepository.UpdateAddressAsync(address);
        }
    }
}
