using DEKODE.AttendMe.Data.Model.Entities;
using System;
using System.Collections.Generic;

namespace DEKODE.AttendMe.Data.Access.Contract.Queries
{
    public interface IAccountQueriesRepository
    {
        // IList<AccountDTO> GetAccountList();
        IList<Account> GetAccountList();
        Account GetById(Guid accountGuid);
    }
}
