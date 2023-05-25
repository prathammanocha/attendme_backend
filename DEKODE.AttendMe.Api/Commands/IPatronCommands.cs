using DEKODE.AttendMe.Api.Model.Entities;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public interface IPatronCommands
    {
        Task<bool> SaveVisitor(Patron visitor);

        Task<bool> DeleteVisitor(int visitorId, int organisationId);
    }
}