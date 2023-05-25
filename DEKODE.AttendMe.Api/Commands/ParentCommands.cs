using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public class ParentCommands : IParentsCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public ParentCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteParent(int parentId, int organisationId)
        {
            var parent = _dbContext.Parents.FirstOrDefault(x => x.Id == parentId && x.OrganisationId == organisationId);
            parent.IsDeleted = true;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveParent(Parents parent)
        {
            if (parent.Id == 0)
            {
                parent.Guid = Guid.NewGuid();
                await _dbContext.Parents.AddAsync(parent);
            }
            else
            {
                var newParent = new Parents()
                {
                    FirstName = parent.FirstName,
                    LastName = parent.LastName,
                    Company = parent.Company,
                    Phone = parent.Phone,
                    Email = parent.Email,
                    Guid = parent.Guid,
                    Workingwc = parent.Workingwc,
                    ChildSafety = parent.ChildSafety,
                    VDS = parent.VDS,
                    PatronTypeId = parent.PatronTypeId,
                    StudentId = parent.StudentId,
                    OrganisationId = parent.OrganisationId,
                    AuditUser = parent.AuditUser,
                    IsDeleted = parent.IsDeleted,
                };

                await _dbContext.Parents.AddAsync(newParent);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
