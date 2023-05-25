using DEKODE.AttendMe.Data.Transfer.Contract;

namespace DEKODE.AttendMe.Data.Access.Contract.Commands
{
    public interface IAccountCommandsRepository
    {
        void SaveAccount(AccountDTO account);
    }
}
