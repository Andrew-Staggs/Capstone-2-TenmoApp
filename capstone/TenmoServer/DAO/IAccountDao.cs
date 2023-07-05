using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDao
    {

        decimal GetBalanceByUsername(string username);
        Account AddFundsFromBalance(decimal fundsToAdd);
        Account RemoveFundsFromBalance(decimal fundsToRemove);



    }
}
