using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class EmployeeProfile : Profile
    {
        //public EmployeeProfile()
        //{
        //    CreateMap<Employee, EmployeeDTO>()
        //        .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
        //        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
        //        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
        //        .ForMember(dest => dest.RefNo, opt => opt.MapFrom(src => src.RefNo))
        //        .ReverseMap();
        //}
    }
}
