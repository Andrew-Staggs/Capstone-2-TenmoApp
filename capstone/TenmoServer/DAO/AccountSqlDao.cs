using System;
using System.Data.SqlClient;
using System.Security.Principal;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDao : IAccountDao
    {
      

        private readonly string connectionString;
        public AccountSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Account GetBalanceByUsername(string username)
        {

            string sql = "SELECT balance, account_id, account.user_id, username FROM account " +
                         "JOIN tenmo_user ON account.user_id = tenmo_user.user_id " + 
                         "WHERE username = @user_name; ";

            Account account = new Account(); 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_name", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        account = MapRowToAccount(reader);
                    }


                }

                return account; 

            }


        }


        public Account AddFundsFromBalance(decimal fundsToAdd)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountBalanceById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Account RemoveFundsFromBalance(decimal fundsToRemove)
        {
            throw new System.NotImplementedException();
        }


        private Account MapRowToAccount(SqlDataReader reader)
        {

            Account account = new Account();

            account.Balance = Convert.ToDecimal(reader["balance"]);
            account.Account_Id = Convert.ToInt32(reader["account_id"]);
            account.User_Id = Convert.ToInt32(reader["user_id"]);
            account.Username = Convert.ToString(reader["username"]);
            return account; 

        }

    }
}
