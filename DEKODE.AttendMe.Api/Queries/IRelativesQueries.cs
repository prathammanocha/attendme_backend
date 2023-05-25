using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public interface IRelativesQueries
    {
        Task<IEnumerable<Relatives>> GetAllRelativesAsync(int organisationId);
        Task<Relatives> GetRelativesByStudentIdAsync(int studentId);
        Task<IEnumerable<PatronType>> GetRelativeTypesAsync();
    }
}
