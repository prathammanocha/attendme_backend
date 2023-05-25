using System;
using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class RelativesProfile : Profile
    {
        public RelativesProfile()
        {
            CreateMap<Relatives, RelativesDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Workingwc, opt => opt.MapFrom(src => src.Workingwc))
                .ForMember(dest => dest.ChildSafety, opt => opt.MapFrom(src => src.ChildSafety))
                .ForMember(dest => dest.VDS, opt => opt.MapFrom(src => src.VDS))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.PatronTypeId, opt => opt.MapFrom(src => src.PatronTypeId))
                .ForMember(dest => dest.OrganisationId, opt => opt.MapFrom(src => src.OrganisationId))
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
