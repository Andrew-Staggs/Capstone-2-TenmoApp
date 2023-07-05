using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public TenmoApiService(string apiUrl) : base(apiUrl) { }

        // Add methods to call api here...

        public decimal GetBalanceByUsername()
        {
        

            RestRequest request = new RestRequest("account");
            IRestResponse<Account> response = client.Get<Account>(request);

            decimal currentBalance = response.Data.Balance;
            return currentBalance;
           

        }
          
    }
}
