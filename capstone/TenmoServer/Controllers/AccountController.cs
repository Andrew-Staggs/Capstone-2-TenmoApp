using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDao accountDao;
        private readonly IUserDao userDao;
        public AccountController(IAccountDao accountDao, IUserDao userDao)
        {
            this.accountDao = accountDao;
            this.userDao = userDao;
        }

        [HttpGet()]

        public ActionResult<Account> GetBalance()
        {
            User user = userDao.GetUserByUsername(User.Identity.Name);

            Account account = accountDao.GetBalance(user.Username);

            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut()]

        public ActionResult<Account> UpdateBalance(Transfer transfer)
        {
          

            accountDao.UpdateBalanceReceived(transfer);
         Account accountReturned = accountDao.UpdateBalanceSent(transfer, User.Identity.Name);

            return accountReturned;

        }

    }




}

