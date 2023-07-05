using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDao
    {

        Account GetAccountBalanceById(int id);
        Account AddFundsFromBalance(decimal fundsToAdd);
        Account RemoveFundsFromBalance(decimal fundsToRemove);


    }
}
