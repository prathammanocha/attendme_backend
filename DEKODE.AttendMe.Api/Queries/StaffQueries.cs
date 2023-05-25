using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public class StaffQueries : IStaffQueries
    {
        private readonly AttendMeDbContext _dbContext;

        public StaffQueries(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Staff>> GetAllAsync(int organisationId)
        {
            // var sql = orgId.ToQueryString();

            //return await _dbContext.StaffMembers.Where(s => s.OrganisationId == orgId && s.IsDeleted == false
            //                    && DateTime.Now >= s.EffectiveStartDate && DateTime.Now <= s.EffectiveEndDate)
            //                .Include(s => s.Organisation) // Eager load nested entity/object. Default behaviour is lazy loading.
            //                .ToListAsync();

            var query = _dbContext.StaffMembers.Where(p => p.OrganisationId == organisationId &&
                                                           p.IsDeleted == false &&
                                                           p.EffectiveEndDate == new System.DateTime(9999, 12, 31));

            return await query.ToListAsync();
        }

        public async Task<Staff> GetByIdAsync(int staffId)
        {
            //return await _dbContext.StaffMembers.FirstOrDefaultAsync(s => s.Id == staffId && s.IsDeleted == false
            //                    && DateTime.Now >= s.EffectiveStartDate && DateTime.Now <= s.EffectiveEndDate);

            return await _dbContext.StaffMembers.FindAsync(staffId);
        }
    }
}