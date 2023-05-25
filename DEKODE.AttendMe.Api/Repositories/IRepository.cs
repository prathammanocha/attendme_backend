using DEKODE.AttendMe.Api.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Repositories
{
    public interface IRepository<T> where T : TemporalEntityBase
    {
        Task<IList<T>> GetAllAsync(int organisationId);

        Task<T> GetByIdAsync(int id);
    }
}