using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDao 
    {
        Transfer InsertNewTransfer(Transfer transfer);
        List<Transfer> ViewTransfers(string username);

    }
}
