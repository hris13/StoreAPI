using AutoMapper;
using store.Models;
using storeDTO.Account;
using storeDTO.Address;

namespace store.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountDTO, Account>().ReverseMap();
            CreateMap <UpdateDTO, Account>();
            CreateMap<UpdateAddressDTO, Address>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
        
    }
}
