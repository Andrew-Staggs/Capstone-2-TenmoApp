using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Models
{
    public class Account
    {

        public int Account_Id { get; set; }
        public int User_Id { get; set; }
        public decimal Balance { get; set; } = 1000M;

        public Account()
        {

        }
        public Account(int account_id, int user_Id) : base()
        {
            User_Id = user_Id;
            Account_Id = account_id;

        }

        public Account(int user_Id)
        {
            User_Id = user_Id;

        }

        public decimal GetBalanceByUsername(string username)

        {

            return Balance;

        }


    }
}
