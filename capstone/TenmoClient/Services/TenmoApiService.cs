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

        public List<ApiUser> GetUsers()
        {
            RestRequest request = new RestRequest("user");

            IRestResponse<List<ApiUser>> response = client.Get<List<ApiUser>>(request);
            List<ApiUser> users = response.Data;

            
            return users; 
        }

        //method to receive user dollar amount:
        public Transfer AmountToSendUser()
        {
            Transfer transfer = new Transfer(); 
            string amountToSend = Console.ReadLine();
            decimal amount = decimal.Parse(amountToSend);
            transfer.Amount = amount; // adds amount user enteres to transfer object
            return transfer; //returns transfer object with the amount to pass to the controller

        }


        public Transfer UserToSendTo()
        {
            Transfer transfer = new Transfer();
          
            string idToSendTo = Console.ReadLine();
            //get account to send funds to by ID. might need method.
           
            return transfer; //returns transfer object with the amount to pass to the controller

        }

       public Transfer SendTransfer(Transfer transfer)
        {
            RestRequest request = new RestRequest("transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);
            Transfer result = response.Data;
            return result;
        }


    }
}
