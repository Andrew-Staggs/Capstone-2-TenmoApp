using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {

        private readonly ITransferDao transferDao;
        private readonly IUserDao userDao;
        private readonly IAccountDao accountDao;
        public TransferController(ITransferDao transferDao, IUserDao userDao, IAccountDao accountDao)
        {
            this.transferDao = transferDao;
            this.userDao = userDao;
            this.accountDao = accountDao;
        }

        [HttpGet()]

        public ActionResult<List<User>> DisplayUsers()
        {
            IList<User> users = userDao.GetUsers();


            if (users != null)
            {
                return Ok(users);

            }

            else
            {
                return NotFound();

            }
        }

        [HttpPost()]

        public ActionResult<Transfer> TransferMoney(Transfer transfer)
        {
           Account account = accountDao.GetAccountIdByUserId(transfer.Account_To);
            Account accountFrom = accountDao.GetAccountIdByUserId(transfer.Account_From); // converts both user ids to both account ids 
            transfer.Account_To = account.Account_Id;
            transfer.Account_From = accountFrom.Account_Id; // adding both accounts Ids to transfer objects
            accountDao.UpdateBalanceReceived(transfer);
            Account accountReturned = accountDao.UpdateBalanceSent(transfer, User.Identity.Name);
            Transfer newTransfer = transferDao.InsertNewTransfer(transfer);
            
           

            return newTransfer;

        }




    }
}
