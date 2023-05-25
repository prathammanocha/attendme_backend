using DEKODE.AttendMe.Api.Model.Entities;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public interface IStaffCommands
    {
        Task<bool> SaveStaff(Staff staff);

        Task DeleteStaffAsync(int staffId);
    }
}