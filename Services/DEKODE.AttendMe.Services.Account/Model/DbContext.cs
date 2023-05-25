//using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DEKODE.AttendMe.Services.Account.Model
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        //public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<AccSbscrptn> AccSbscrptns { get; set; }
    }
}