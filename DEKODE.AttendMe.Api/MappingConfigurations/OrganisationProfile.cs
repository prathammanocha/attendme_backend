using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class OrganisationProfile : Profile
    {
        public OrganisationProfile()
        {
            CreateMap<Organisation, OrganisationDTO>()
                //.ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.ContactPhone))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                //.ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                //.ForMember(dest => dest.AccSbscrptnId, opt => opt.MapFrom(src => src.AccSbscrptnId))
                .ReverseMap();
        }
    }
}