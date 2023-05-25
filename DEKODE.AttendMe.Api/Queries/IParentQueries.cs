using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public interface IParentQueries
    {
        Task<IEnumerable<Parents>> GetAllParentsAsync(int organisatioinId);
        Task<Parents> GetParentsByStudentIdAsync(int studentId);
        Task<IEnumerable<PatronType>> GetParentTypesAsync();
    }
}