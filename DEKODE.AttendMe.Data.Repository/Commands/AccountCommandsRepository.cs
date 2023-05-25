using DEKODE.AttendMe.Data.Access.Contract.Commands;
using DEKODE.AttendMe.Data.Transfer.Contract;
using System;

namespace DEKODE.AttendMe.Data.Access.Repository.Commands
{
    public class AccountCommandsRepository : IAccountCommandsRepository
    {
        public void SaveAccount(AccountDTO account)
        {
            // Persist the account record in a data store.
            throw new NotImplementedException();
        }
    }
}
