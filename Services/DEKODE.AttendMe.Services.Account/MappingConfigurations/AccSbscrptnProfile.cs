using AutoMapper;
using DEKODE.AttendMe.Services.Account.Entities;
using AccSbscrptnModel = DEKODE.AttendMe.Services.Account.Model.AccSbscrptn;

namespace DEKODE.AttendMe.Services.Account.MappingConfigurations
{
    public class AccSbscrptnProfile : Profile
    {
        public AccSbscrptnProfile()
        {
            CreateMap<AccSbscrptnModel, AccSbscrptnDTO>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.SubscriptionTypeGuid, opt => opt.MapFrom(src => src.SbscrptnType.Guid))
                .ForMember(dest => dest.SubscriptionType, opt => opt.MapFrom(src => src.SbscrptnType.Description))
                .ForMember(dest => dest.SubscriptionAmount, opt => opt.MapFrom(src => src.SbscrptnType.Amount))
                .ForMember(dest => dest.DevicesAllowed, opt => opt.MapFrom(src => src.SbscrptnType.DevicesAllowed))
                .ReverseMap();
        }
    }
}