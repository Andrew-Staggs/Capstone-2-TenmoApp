using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using TenmoServer.Exceptions;
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

        public Transfer InsertNewTransfer(Transfer transfer)
        {
            string sql = "INSERT INTO transfer (transfer_type_id, transfer_status_id, account_from, account_to, amount) " +
                "VALUES (2, 2, @account_from, @account_to, @amount)";

            //Transfer newTransfer = new Transfer();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@account_from", transfer.Account_From);
                    cmd.Parameters.AddWithValue("@account_to", transfer.Account_To);
                    cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                     cmd.ExecuteNonQuery();


                    return transfer;
                }
            }
        }
                
        public List<Transfer> ViewTransfers(string username)

        {

            string sql = "SELECT transfer_id, transfer_type_id, transfer_status_id, account_from, account_to, amount FROM transfer " +
                            "JOIN account ON account_id = account_from " +
                            "JOIN tenmo_user ON tenmo_user.user_id = account.user_id " +
                            "WHERE username = @username; ";

            List<Transfer> transfers = new List<Transfer>();
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Transfer transfer = new Transfer();
                       
                         transfer = MapRowToTransfer(reader);
                        transfers.Add(transfer);
                        
                    }

                  
                }
                return transfers;


            }


            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }


        }


                // create method to add row to table. Called 
                private Transfer MapRowToTransfer(SqlDataReader reader)
                {
                    Transfer transfer = new Transfer();

                   
                    transfer.Transfer_Id = Convert.ToInt32(reader["transfer_id"]);
                    transfer.Account_From = Convert.ToInt32(reader["account_from"]);
                    transfer.Account_To = Convert.ToInt32(reader["account_to"]);
                    transfer.Amount = Convert.ToDecimal(reader["amount"]);
                    transfer.Transfer_Type_Id = Convert.ToInt32(reader["transfer_type_id"]);
                    transfer.Transfer_Status_Id = Convert.ToInt32(reader["transfer_status_id"]);

                    return transfer;
                }




            
        }
    }

