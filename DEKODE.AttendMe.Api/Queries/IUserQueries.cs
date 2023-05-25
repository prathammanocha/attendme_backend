using DEKODE.AttendMe.Api.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public interface IUserQueries
    {
        Task<OrganisationUser> FindByEmailAsync(string email);

        Task<OrganisationUser> FindByEmailAsync(string email, int organisationId);

        Task<IList<OrganisationUser>> GetAllAsync(int organisationId);

        Task<OrganisationUser> GetByIdAsync(int orgUserId);
    }
}