using DEKODE.AttendMe.Api.Model.Entities;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public interface IParentsCommands
    {
        Task<bool> SaveParent(Parents parent);

        Task<bool> DeleteParent(int parentId, int organisationId);
    }
}
