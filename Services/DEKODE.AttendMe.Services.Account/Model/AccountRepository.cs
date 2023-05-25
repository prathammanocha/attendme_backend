using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Services.Account.Model
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext _dbContext;

        public AccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> GetAccountIdAsync(Guid accountGuid)
        {
            var res = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Guid == accountGuid);

            return res?.Id;
        }

        public async Task<IList<Account>> GetAllAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int accountId)
        {
            return await _dbContext.Accounts.FindAsync(accountId);
        }

        public async Task SaveAccountAsync(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}