using DEKODE.AttendMe.Api.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public interface IStaffQueries
    {
        Task<IList<Staff>> GetAllAsync(int organisationId);

        Task<Staff> GetByIdAsync(int staffId);
    }
}