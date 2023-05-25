using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Queries
{
    //public class AccountQueries : IAccountQueries
    //{
    //    private readonly AttendMeDbContext _dbContext;

    //    public AccountQueries(AttendMeDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task<Account> GetByIdAsync(int accountId)
    //    {
    //        return await _dbContext.Accounts.FindAsync(accountId);
    //    }

    //    public async Task<IList<Account>> GetAllAsync()
    //    {
    //        // return await _dbContext.Accounts.ToListAsync();
    //        return await _dbContext.Accounts.Where(p => p.IsDeleted == false &
    //                                                    p.EffectiveEndDate == new System.DateTime(9999, 12, 31))
    //            .ToListAsync();
    //    }

    //    public async Task<int?> GetAccountIdAsync(Guid accountGuid)
    //    {
    //        var result = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Guid == accountGuid);

    //        return result?.Id;
    //    }
    //}
}