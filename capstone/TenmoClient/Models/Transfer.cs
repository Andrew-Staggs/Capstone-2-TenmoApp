using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Models
{
        public class Transfer
        {
            public int Transfer_Id { get; set; }
            public int Transfer_Type_Id { get; set; }
            public int Account_From { get; set; }
            public int Account_To { get; set; }

            public decimal Amount { get; set; }

            public int Transfer_Status_Id { get; set; }


            public Transfer()

            {

            }

            public Transfer(int transfer_type_id, int account_from, int account_to, decimal amount, int transfer_status_id)

            {

                Transfer_Type_Id = transfer_type_id;
                Account_From = account_from;
                Account_To = account_to;
                Amount = amount;
                Transfer_Status_Id = transfer_status_id;

            }
         

        }
    }

