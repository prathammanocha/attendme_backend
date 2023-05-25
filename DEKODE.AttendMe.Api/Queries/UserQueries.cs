using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly AttendMeDbContext _dbContext;

        public UserQueries(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<OrganisationUser>> GetAllAsync(int organisationId)
        {
            var query = _dbContext.OrganisationUsers.Where(p => p.OrganisationId == organisationId &&
                                                           p.IsDeleted == false &&
                                                           p.EffectiveEndDate == DateTimeHelper.NewEndDateTime());

            return await query.ToListAsync();
        }

        public async Task<OrganisationUser> GetByIdAsync(int orgUserId)
        {
            return await _dbContext.OrganisationUsers.FindAsync(orgUserId);
        }

        public async Task<OrganisationUser> FindByEmailAsync(string email)
        {
            return await _dbContext.OrganisationUsers.FirstOrDefaultAsync(u => u.Email == email && u.EffectiveEndDate == DateTimeHelper.NewEndDateTime());
        }

        public async Task<OrganisationUser> FindByEmailAsync(string email, int organisationId)
        {
            return await _dbContext.OrganisationUsers.FirstOrDefaultAsync(u => u.Email == email &&
                                                                               u.OrganisationId == organisationId &&
                                                                               u.EffectiveEndDate == DateTimeHelper.NewEndDateTime());
        }
    }
}