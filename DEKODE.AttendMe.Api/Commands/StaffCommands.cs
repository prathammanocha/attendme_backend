using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using DEKODE.AttendMe.Common;

namespace DEKODE.AttendMe.Api.Commands
{
    public class StaffCommands : IStaffCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public StaffCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveStaff(Staff staff)
        {
            if (staff.Id == 0)
            {
                staff.Guid = Guid.NewGuid();

                await _dbContext.StaffMembers.AddAsync(staff);
            }
            else
            {
                // End (update EffectiveEndDate) existing record.
                var endDate = DateTime.Now;
                var existingStaff = _dbContext.StaffMembers.FirstOrDefault(x => x.Id == staff.Id);
                existingStaff.EffectiveEndDate = endDate;

                // Start (Insert) new record.
                var newStaff = new Staff()
                {
                    Guid = staff.Guid,
                    ContactEmail = staff.ContactEmail,
                    ContactPhone = staff.ContactPhone,
                    EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                    EffectiveStartDate = endDate,
                    FirstName = staff.FirstName,
                    IsDeleted = staff.IsDeleted,
                    LastName = staff.LastName,
                    OrganisationId = staff.OrganisationId,
                    Pin = staff.Pin,
                    RefNo = staff.RefNo
                };

                await _dbContext.StaffMembers.AddAsync(newStaff);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task DeleteStaffAsync(int staffId)
        {
            var staff = await _dbContext.StaffMembers.FirstOrDefaultAsync(x => x.Id == staffId);

            if (staff != null)
            {
                staff.Delete();
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task AddNewStaff(Staff staff, int orgId)
        {
            // https://stackoverflow.com/questions/25441027/how-do-i-stop-entity-framework-from-trying-to-save-insert-child-objects
            // https://itecnote.com/tecnote/c-how-to-stop-entity-framework-from-trying-to-save-insert-child-objects/
            // _dbContext.StaffMembers.IgnoreAutoIncludes();
            // _dbContext.Entry(organisation).State = EntityState.Detached;

            // var organisation = await _dbContext.Organisations.FirstOrDefaultAsync(x => x.Guid == staff.Organisation.Guid);

            ////TODO ~ Repeate, create common method
            //var orgId = await _dbContext.Organisations.Where(o => o.Guid == staff.Organisation.Guid && o.IsDeleted == false
            //                    && DateTime.Now >= o.EffectiveStartDate && DateTime.Now <= o.EffectiveEndDate)
            //                .Select(o => o.Id).FirstOrDefaultAsync();

            staff.OrganisationId = orgId;

            //TODO ~ Find a better alternative.
            // ~ Prevent EF from trying to save/insert child objects.
            // staff.Organisation = null;

            await _dbContext.StaffMembers.AddAsync(staff);
        }

        private Task UpdateStaff(Staff staff)
        {
            return Task.CompletedTask;
        }
    }
}
