using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Repositories
{
    public interface IStudentLogRepository
    {
        Task<IList<StudentLog>> GetStudentLogsAsync(int studentId, DateTime fromDate, DateTime toDate);
    }
}
