using DEKODE.AttendMe.Api.Model;

namespace DEKODE.AttendMe.Api.Commands
{
    public class AccountUserCommands : IAccountUserCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public AccountUserCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task SaveAccountUserAsync(AccountUser accountUser)
        //{
        //    if (accountUser.Id == 0)
        //        AddNewAccountUser(accountUser);
        //    else
        //        UpdateAccountUser(accountUser);

        //    await _dbContext.SaveChangesAsync();
        //}

        //private async void AddNewAccountUser(AccountUser accountUser)
        //{
        //    // https://stackoverflow.com/questions/25441027/how-do-i-stop-entity-framework-from-trying-to-save-insert-child-objects
        //    // https://itecnote.com/tecnote/c-how-to-stop-entity-framework-from-trying-to-save-insert-child-objects/
        //    // _dbContext.StaffMembers.IgnoreAutoIncludes();
        //    // _dbContext.Entry(organisation).State = EntityState.Detached;

        //    // var organisation = await _dbContext.Organisations.FirstOrDefaultAsync(x => x.Guid == staff.Organisation.Guid);

        //    ////TODO ~ Repeate, create common method
        //    //var orgId = await _dbContext.Organisations.Where(o => o.Guid == staff.Organisation.Guid && o.IsDeleted == false
        //    //                    && DateTime.Now >= o.EffectiveStartDate && DateTime.Now <= o.EffectiveEndDate)
        //    //                .Select(o => o.Id).FirstOrDefaultAsync();

        //    //TODO ~ Find a better alternative.
        //    // ~ Prevent EF from trying to save/insert child objects.
        //    accountUser.Account = null;

        //    await _dbContext.AccountUsers.AddAsync(accountUser);
        //}

        //private async void UpdateAccountUser(AccountUser accountUser)
        //{
        //    // End (update EffectiveEndDate) existing record.

        //    // Start (Insert) new record.
        //}
    }
}