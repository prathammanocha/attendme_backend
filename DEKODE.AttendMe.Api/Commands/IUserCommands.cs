using DEKODE.AttendMe.Api.Model.Entities;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public interface IUserCommands
    {
        Task<bool> ResetUserPassword(string userName, int organisationId, string newPassword);

        Task<bool> SaveUser(OrganisationUser orgUser);
    }
}