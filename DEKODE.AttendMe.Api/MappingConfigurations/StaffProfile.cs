using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffDTO, Staff>()
                //.ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.ContactPhone))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.Pin, opt => opt.MapFrom(src => src.Pin))
                .ForMember(dest => dest.RefNo, opt => opt.MapFrom(src => src.RefNo))
                .ReverseMap();

            //CreateMap<Staff, StaffDTO>()
            //    .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.ContactPhone))
            //    .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
            //    .ForMember(dest => dest.Pin, opt => opt.MapFrom(src => src.Pin))
            //    .ForMember(dest => dest.RefNo, opt => opt.MapFrom(src => src.RefNo));
            //    //.ForMember(dest => dest.OrganisationGuid, opt => opt.MapFrom(src => src.Organisation.Guid));
            //    // .ReverseMap();

            // .ReverseMap();
        }
    }
}