using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Repositories
{
    public class StudentLogRepository : IStudentLogRepository
    {
        private readonly AttendMeDbContext _dbContext;

        public StudentLogRepository(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<StudentLog>> GetStudentLogsAsync(int studentId, DateTime fromDateTime, DateTime toDateTime)
        {
            var query = _dbContext.StudentLogs
                            .Include(sl => sl.Student)
                            .Include(sl => sl.StudentLogReason)
                            .Include(sl => sl.Patron)
                            .Where(sl => sl.StudentId == studentId &&
                                        sl.LogDateTime >= fromDateTime &&
                                        sl.LogDateTime <= toDateTime);

            return await query.ToListAsync();
        }
    }
}
