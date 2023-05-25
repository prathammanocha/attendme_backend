using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    public interface IPatronQueries
    {
        Task<IList<Patron>> GetAllAsync(int organisationId);

        Task<Patron> GetByIdAsync(int patronId);

        Task<IList<VisitorLog>> GetVistorLogs(DateTime? fromDateTime, DateTime? toDateTime, int organisationId);

        Task<IList<PatronType>> GetPatronTypesAsync();
    }
}