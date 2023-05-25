using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class PatronProfile : Profile
    {
        public PatronProfile()
        {
            CreateMap<Patron, PatronDTO>()
                .ReverseMap();
        }
    }
}