using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDao : ITransferDao
    {

        private readonly string connectionString;
        public TransferSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

        public List<Transfer> TransferMoneyToUser(string username)
        {
            string sql = "SELECT tenmo_user.user_id, username FROM tenmo_user " +
               "JOIN account ON account.user_id = tenmo_user.user_id " +
               "WHERE username != @user_name;";

            List<Transfer> transferRecipients = new List<Transfer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_name", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Transfer transfer = new Transfer();

                        transfer = MapRowToTransfer(reader);
                        transferRecipients.Add(transfer);
                    }
                   

                }
                return transferRecipients;


            }


        }
      

        private Transfer MapRowToTransfer(SqlDataReader reader)
        {
            Transfer transfer = new Transfer();

            transfer.Transfer_Id = Convert.ToInt32("transfer_id");
            transfer.Account_From = Convert.ToInt32("account_from");
            transfer.Account_To = Convert.ToInt32("account_to");
            transfer.Amount = Convert.ToDecimal("amount");
            transfer.Transfer_Type_Id = Convert.ToInt32("transfer_type_id");
            transfer.Transfer_Status_Id = Convert.ToInt32("transfer_status_id");

            return transfer; 
        }


    }
}
