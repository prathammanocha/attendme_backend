using DEKODE.AttendMe.Data.Access.Contract.Queries;
using DEKODE.AttendMe.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DEKODE.AttendMe.Data.Access.Queries
{
    public class AccountQueriesRepository : IAccountQueriesRepository
    {
        IList<AccountDTO> Accounts = new List<AccountDTO>
        {
            new AccountDTO
                {
                    IdentityId = Guid.Parse("AE5F34FC-C750-4F64-9A1C-8D72443F925C"),
                    ABN = "123 456 789",
                    Address = new AddressDTO
                        {
                        Country = "Australia",
                        PostCode = "3000",
                        State = "VIC",
                        StreetName = "Main Street",
                        StreetNo = "1",
                        Suburb = "Melbourne"
                        },
                    ContactName = "Steve Smith",
                    ContactPhone = "0421 196 123",
                    Email = "s.smith@acb.com.au",
                    Name = "Australian Cricket Board"
                },
                new AccountDTO
                {
                    IdentityId = Guid.Parse("AF3DE939-BE70-4EE5-B9A0-09CC026540F8"),
                    ABN = "987 654 321",
                    Address = new AddressDTO
                        {
                        Country = "Australia",
                        PostCode = "3122",
                        State = "VIC",
                        StreetName = "Station Street",
                        StreetNo = "2",
                        Suburb = "Hawthorn"
                        },
                    ContactName = "David Warner",
                    ContactPhone = "0421 196 456",
                    Email = "d.warner@acb.com.au",
                    Name = "Australian Cricket Board"
                }
        };

        public AccountDTO GetById(Guid accountId)
        {
            // Get the account record from a data store
            // Below is for demo purposes only
            return GetAccountList().FirstOrDefault(a => a.IdentityId == accountId);
        }

        public IList<AccountDTO> GetAccountList()
        {
            // Get the account record from a data store
            // Below is for demo purposes only
            return Accounts;
        }
    }
}
