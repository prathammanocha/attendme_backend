using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Api.Queries;
using DEKODE.AttendMe.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Commands
{
    public class UserCommands : IUserCommands
    {
        private readonly AttendMeDbContext _dbContext;
        private readonly IUserQueries _organisationQueries;

        public UserCommands(AttendMeDbContext dbContext, IUserQueries organisationQueries)
        {
            _dbContext = dbContext;
            _organisationQueries = organisationQueries;
        }

        public async Task<bool> SaveUser(OrganisationUser orgUser)
        {
            if (orgUser.Id == 0)
            {
                orgUser.Guid = Guid.NewGuid();

                // ~TODO Generate temp password
                orgUser.Password = "$2a$11$0yNqYtIew9pkuD/qpufX0.48klW6qfBZ3oWIsPdnrqjItvPziWyq.";

                await _dbContext.OrganisationUsers.AddAsync(orgUser);
            }
            else
            {
                // End (update EffectiveEndDate) existing record.
                var endDate = DateTime.Now;
                var user = _dbContext.OrganisationUsers.FirstOrDefault(x => x.Id == orgUser.Id);
                user.EffectiveEndDate = endDate;

                // Start (Insert) new record.
                var newUser = new OrganisationUser()
                {
                    EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                    EffectiveStartDate = endDate,
                    Email = orgUser.Email,
                    FirstName = orgUser.FirstName,
                    LastName = orgUser.LastName,
                    OrganisationId = user.OrganisationId,
                    Password = user.Password,
                    Guid = user.Guid,
                    //Id = user.Id
                };

                await _dbContext.OrganisationUsers.AddAsync(newUser);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ResetUserPassword(string userName, int organisationId, string newPassword)
        {
            var orgUser = await _organisationQueries.FindByEmailAsync(userName, organisationId);

            if (orgUser != null)
            {
                orgUser.Password = newPassword;

                /* If the entry is being tracked (retrieved by key), then invoking Update API is not needed.
                The API only needs to be invoked if the entry was not tracked.
                https://www.learnentityframeworkcore.com/dbcontext/modifying-data */
                _dbContext.OrganisationUsers.Update(orgUser);

                // Save changes in database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}