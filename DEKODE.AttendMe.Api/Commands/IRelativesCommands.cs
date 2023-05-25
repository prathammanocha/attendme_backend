using DEKODE.AttendMe.Api.Model.Entities;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public interface IRelativesCommands
    {
        Task<bool> SaveRelative(Relatives relative);

        Task<bool> DeleteRelative(int relativeId, int organisationId);
    }
}
