using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}
