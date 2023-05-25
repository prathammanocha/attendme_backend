using DEKODE.AttendMe.Data.Access.Contract.Queries;
using DEKODE.AttendMe.Data.Model.Entities;
using DEKODE.AttendMe.Data.Transfer.Contract;
using System;
using System.Collections.Generic;

namespace DEKODE.AttendMe.BusinessServices.Queries
{
    public class AccountQueries : IAccountQueries
    {
        private readonly IAccountQueriesRepository _queriesRepository;

        public AccountQueries(IAccountQueriesRepository queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }

        public IList<AccountDTO> GetAllAccounts()
        {
            return _queriesRepository.GetAccountList();
        }

        public AccountDTO GetAccountById(Guid accountGuid)
        {
            
            return _queriesRepository.GetById(accountGuid);
        }
    }
}
