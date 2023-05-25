using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public class RelativeCommands : IRelativesCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public RelativeCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteRelative(int relativeId, int organisationId)
        {
            var relative = _dbContext.Relatives.FirstOrDefault(x => x.Id == relativeId && x.OrganisationId == organisationId);
            relative.IsDeleted = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveRelative(Relatives relative)
        {
            if (relative.Id == 0)
            {
                relative.Guid = Guid.NewGuid();
                await _dbContext.Relatives.AddAsync(relative);
            }
            else
            {

                var newRelative = new Relatives()
                {
                    FirstName = relative.FirstName,
                    LastName = relative.LastName,
                    Company = relative.Company,
                    Phone = relative.Phone,
                    Email = relative.Email,
                    Guid = relative.Guid,
                    Workingwc = relative.Workingwc,
                    ChildSafety = relative.ChildSafety,
                    VDS = relative.VDS,
                    PatronTypeId = relative.PatronTypeId,
                    StudentId = relative.StudentId,
                    OrganisationId = relative.OrganisationId,
                    AuditUser = relative.AuditUser,
                    IsDeleted = relative.IsDeleted,
                };

                await _dbContext.Relatives.AddAsync(newRelative);
            }
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
