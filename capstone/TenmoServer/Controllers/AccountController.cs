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
      
        public ActionResult<Account> GetAccountBalanceById(int id)
        {

            Account balance = accountDao.GetAccountBalanceById(id);

            if (balance != null)
            {
                return Ok(balance);
            }
            else
            {
                return NotFound();
            }

                




        }




    }




    }

