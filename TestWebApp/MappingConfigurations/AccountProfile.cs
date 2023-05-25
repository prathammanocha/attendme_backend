using AutoMapper;
using DEKODE.AttendMe.Data.Contract;
using TestWebApp.Models;

namespace TestWebApp.MappingConfigurations
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            // Default mapping when property names are same
            //CreateMap<Account, AccountViewModel>();

            // Mapping when property names are different
            CreateMap<AccountDTO, AccountViewModel>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.StreetNo, opt => opt.MapFrom(src => src.Address.StreetNo))
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Address.StreetName))
                .ForMember(dest => dest.Suburb, opt => opt.MapFrom(src => src.Address.Suburb))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Address.PostCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ReverseMap();
        }
    }
}
