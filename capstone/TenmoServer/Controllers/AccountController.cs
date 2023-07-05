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

        [HttpGet("{username}")]
      
        public ActionResult<decimal> GetAccountBalanceByName(string username)
        {

            decimal balance = accountDao.GetBalanceByUsername(username);

            if (username != null)
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

