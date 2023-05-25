using DEKODE.AttendMe.Api.Model;

namespace DEKODE.AttendMe.Api.Commands
{
    public class AccountCommands : IAccountCommands
    {
        private readonly AttendMeDbContext _dbContext;

        public AccountCommands(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task SaveAccountAsync(Account account)
        //{
        //    await _dbContext.Accounts.AddAsync(account);
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}