using DEKODE.AttendMe.Data.Transfer.Contract;
using System;
using System.Collections.Generic;

namespace DEKODE.AttendMe.BusinessServices.Queries
{
    public interface IAccountQueries
    {
        AccountDTO GetAccountById(Guid accountGuid);
        IList<AccountDTO> GetAllAccounts();

    }
}
