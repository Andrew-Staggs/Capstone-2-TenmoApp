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
        public AccountController (IAccountDao accountDao )
        {
            this.accountDao = accountDao; 

        }

        [HttpGet("{id}")]
      
        public IActionResult GetAccountBalanceById(int id)
        {

            //get current user info below

            try
            {
                Account account = new Account(;

                account.Balance = accountDao.GetAccountBalanceById(id);

                currentUser.

                }


            catch ()

            {



            }



        }




    }




    }
}
