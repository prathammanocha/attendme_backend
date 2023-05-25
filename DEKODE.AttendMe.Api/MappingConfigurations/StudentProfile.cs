using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;
namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.OrganisationId, opt => opt.MapFrom(src => src.OrganisationId));
        }
    }
}
