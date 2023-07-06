namespace TenmoServer.Models
{
    public class Account : User 
    {
        public int Account_Id { get; set; } 
        public int User_Id { get; set; }
        public decimal Balance { get; set; }

         
        public Account()
        {

        }
        public Account (int account_id, int user_Id) : base ()
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
