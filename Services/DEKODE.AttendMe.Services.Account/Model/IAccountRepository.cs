using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Services.Account.Model
{
    public interface IAccountRepository
    {
        Task<IList<Account>> GetAllAsync();

        Task<Account> GetByIdAsync(int accountId);

        Task<int?> GetAccountIdAsync(Guid accountGuid);

        Task SaveAccountAsync(Account account);
    }
}