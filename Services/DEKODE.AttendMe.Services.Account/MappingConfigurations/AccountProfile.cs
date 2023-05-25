using AutoMapper;
using DEKODE.AttendMe.Services.Account.Entities;
using AccountModel = DEKODE.AttendMe.Services.Account.Model.Account;

namespace DEKODE.AttendMe.Services.Account.MappingConfigurations
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Default mapping when property names are same
            // CreateMap<Account, AccountDTO>();

            CreateMap<AccountModel, AccountDTO>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StreetNo, opt => opt.MapFrom(src => src.Address.StreetNo))
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Address.StreetName))
                .ForMember(dest => dest.Suburb, opt => opt.MapFrom(src => src.Address.Suburb))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Address.PostCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.ContactPhone))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.ABN, opt => opt.MapFrom(src => src.ABN))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ReverseMap();
        }
    }
}