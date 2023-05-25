using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public class RelativeQueries : IRelativesQueries
    {
        private readonly AttendMeDbContext _dbContext;

        public RelativeQueries(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Relatives>> GetAllRelativesAsync(int organisationId)
        {
            var query = _dbContext.Relatives.Where(r => r.OrganisationId == organisationId &&
                                                       r.IsDeleted == false);

            return await query.ToListAsync();
        }

        public async Task<Relatives> GetRelativesByStudentIdAsync(int studentId)
        {
            return await _dbContext.Relatives.FirstOrDefaultAsync(r => r.StudentId == studentId);
        }

        public async Task<IEnumerable<PatronType>> GetRelativeTypesAsync()
        {
            return await _dbContext.PatronTypes.ToListAsync();
        }
    }
}
