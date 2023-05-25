using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public class PatronCommands : IPatronCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public PatronCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteVisitor(int visitorId, int organisationId)
        {
            var endDate = DateTime.Now;
            var patron = _dbContext.Patrons.FirstOrDefault(x => x.Id == visitorId && x.OrganisationId == organisationId);
            patron.EffectiveEndDate = endDate;
            patron.IsDeleted = true;

            /* If the entry is being tracked (retrieved by key), then invoking Update API is not needed.
                The API only needs to be invoked if the entry was not tracked.
                https://www.learnentityframeworkcore.com/dbcontext/modifying-data */
            //_dbContext.Patrons.Update(patron);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveVisitor(Patron visitor)
        {
            if (visitor.Id == 0)
            {
                visitor.Guid = Guid.NewGuid();

                await _dbContext.Patrons.AddAsync(visitor);
            }
            else
            {
                // End (update EffectiveEndDate) existing record.
                var endDate = DateTime.Now;
                var patron = _dbContext.Patrons.FirstOrDefault(x => x.Id == visitor.Id);
                patron.EffectiveEndDate = endDate;

                // Start (Insert) new record.
                var newPatron = new Patron()
                {
                    CompanyName = visitor.CompanyName,
                    ContactEmail = visitor.ContactEmail,
                    ContactPhone = visitor.ContactPhone,
                    EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                    EffectiveStartDate = endDate,
                    FirstName = visitor.FirstName,
                    Guid = visitor.Guid,
                    IsAuthorizedToCollect = visitor.IsAuthorizedToCollect,
                    IsDeleted = visitor.IsDeleted,
                    LastName = visitor.LastName,
                    OrganisationId = visitor.OrganisationId,
                    PatronTypeId = visitor.PatronTypeId,
                    ReferenceKeyId = visitor.ReferenceKeyId,
                    TermsAndConditionCheck = visitor.TermsAndConditionCheck,
                };

                await _dbContext.Patrons.AddAsync(newPatron);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}