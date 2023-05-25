using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.MappingConfigurations
{
    public class OrganisationUserProfile : Profile
    {
        public OrganisationUserProfile()
        {
            CreateMap<OrganisationUser, OrganisationUserDTO>()
                .ReverseMap();
        }
    }
}