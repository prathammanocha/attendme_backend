using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DEKODE.AttendMe.Api.Queries
{
    //public class AccountUserQueries : IAccountUserQueries
    //{
    //    private readonly AttendMeDbContext _dbContext;

    //    public AccountUserQueries(AttendMeDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task<AccountUser> FindAsync(string username, string password)
    //    {
    //        return await _dbContext.AccountUsers.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
    //    }

    //    public async Task<AccountUser> FindByEmailAsync(string email)
    //    {
    //        // return await _dbContext.AccountUsers.Include(x => x.Account.Organisations.Where(x=>x.Acc)).FirstOrDefaultAsync(u => u.UserName == email);

    //        return await _dbContext.AccountUsers.FirstOrDefaultAsync(u => u.UserName == email);
    //    }

    //}
}