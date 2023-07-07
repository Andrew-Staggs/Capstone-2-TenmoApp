using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDao
    {

        Account GetBalance(string username);
        void UpdateBalanceReceived(Transfer transfer);
        Account UpdateBalanceSent(Transfer transfer, string username);

        Account GetAccountIdByUserId(int userId);



    }
}
