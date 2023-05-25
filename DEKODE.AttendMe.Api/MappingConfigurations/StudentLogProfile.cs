using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class StudentLogProfile : Profile
    {
        public StudentLogProfile()
        {
            CreateMap<StudentLog, StudentLogDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LogDateTime, opt => opt.MapFrom(src => src.LogDateTime))
                .ForMember(dest => dest.LogType, opt => opt.MapFrom(src => src.LogType))
                .ForMember(dest => dest.OtherReason, opt => opt.MapFrom(src => src.OtherReason))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.StudentLogReasonId, opt => opt.MapFrom(src => src.StudentLogReasonId))
                .ForMember(dest => dest.PatronId, opt => opt.MapFrom(src => src.PatronId));

            CreateMap<DEKODE.AttendMe.Api.Model.Enums.LogType, DEKODE.AttendMe.Data.Contract.LogType>();


        }
    }
}
