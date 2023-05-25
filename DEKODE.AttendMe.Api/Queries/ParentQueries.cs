using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public class ParentQueries : IParentQueries
    {
        private readonly AttendMeDbContext _dbContext;

        public ParentQueries(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Parents>> GetAllParentsAsync(int organisationId)
        {
            return await _dbContext.Parents
                .Where(p => p.OrganisationId == organisationId && p.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Parents> GetParentsByStudentIdAsync(int studentId)
        {
            return await _dbContext.Parents
                .FirstOrDefaultAsync(p => p.StudentId == studentId && p.IsDeleted == false);
        }

        public async Task<IEnumerable<PatronType>> GetParentTypesAsync()
        {
            return await _dbContext.PatronTypes.ToListAsync();
        }
    }
}
