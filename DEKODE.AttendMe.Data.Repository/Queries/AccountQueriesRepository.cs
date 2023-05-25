using DEKODE.AttendMe.Data.Access.Contract.Queries;
using DEKODE.AttendMe.Data.Model;
using DEKODE.AttendMe.Data.Model.Entities;
using DEKODE.AttendMe.Data.Transfer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DEKODE.AttendMe.Data.Access.Repository.Queries
{
    public class AccountQueriesRepository : IAccountQueriesRepository
    {
        private readonly AttendMeDbContext _dbContext;
        public AccountQueriesRepository(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //IList<AccountDTO> Accounts = new List<AccountDTO>
        //{
        //    new AccountDTO
        //        {
        //            IdentityId = Guid.Parse("AE5F34FC-C750-4F64-9A1C-8D72443F925C"),
        //            ABN = "123 456 789",
        //            Address = new AddressDTO
        //                {
        //                Country = "Australia",
        //                PostCode = "3000",
        //                State = "VIC",
        //                StreetName = "Main Street",
        //                StreetNo = "1",
        //                Suburb = "Melbourne"
        //                },
        //            ContactName = "Steve Smith",
        //            ContactPhone = "0421 196 123",
        //            Email = "s.smith@acb.com.au",
        //            Name = "Australian Cricket Board"
        //        },
        //        new AccountDTO
        //        {
        //            IdentityId = Guid.Parse("AF3DE939-BE70-4EE5-B9A0-09CC026540F8"),
        //            ABN = "987 654 321",
        //            Address = new AddressDTO
        //                {
        //                Country = "Australia",
        //                PostCode = "3122",
        //                State = "VIC",
        //                StreetName = "Station Street",
        //                StreetNo = "2",
        //                Suburb = "Hawthorn"
        //                },
        //            ContactName = "David Warner",
        //            ContactPhone = "0421 196 456",
        //            Email = "d.warner@acb.com.au",
        //            Name = "Australian Cricket Board"
        //        }
        //};

        public Account GetById(Guid accountGuid)
        {
            // Get the account record from a data store
            // Below is for demo purposes only
            // return GetAccountList().FirstOrDefault(a => a.IdentityId == accountId);

            var accId = GetAccountId(accountGuid);
            return _dbContext.Accounts.FirstOrDefault(a => a.Id == accId);
        }

        public IList<Account> GetAccountList()
        {
            // Get the account record from a data store
            // Below is for demo purposes only
            // return Accounts;
            return _dbContext.Accounts.ToList();
        }

        private int GetAccountId(Guid guid)
        {
            // return _dbContext.Accounts.FirstOrDefault(a => a.Guid == guid).Id;
            return _dbContext.Accounts.Where(a => a.Guid == guid).Select(a => a.Id).SingleOrDefault();
        }
    }
}
