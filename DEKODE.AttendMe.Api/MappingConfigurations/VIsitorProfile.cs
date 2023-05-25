using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;
namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class VisitorLogProfile : Profile
    {
        public VisitorLogProfile()
        {
            CreateMap<VisitorLog, VisitorLogDTO>()
                .ForMember(dest => dest.VisitingPerson, opt => opt.MapFrom(src => src.VisitingPerson))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
                .ForMember(dest => dest.InDateTime, opt => opt.MapFrom(src => src.InDateTime))
                .ForMember(dest => dest.OutDateTime, opt => opt.MapFrom(src => src.OutDateTime))
                .ForMember(dest => dest.PatronId, opt => opt.MapFrom(src => src.PatronId))
                .ForMember(dest => dest.OrganisationId, opt => opt.MapFrom(src => src.OrganisationId));
        }
    }
}