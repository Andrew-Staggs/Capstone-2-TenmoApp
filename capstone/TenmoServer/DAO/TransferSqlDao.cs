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

       
        // create method to add row to table. Called 
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
