﻿using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services;

namespace TenmoClient
{
    public class TenmoApp
    {
        private readonly TenmoConsoleService console = new TenmoConsoleService();
        private readonly TenmoApiService tenmoApiService;

        public TenmoApp(string apiUrl)
        {
            tenmoApiService = new TenmoApiService(apiUrl);
        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (tenmoApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            console.PrintLoginMenu();
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console.PrintError("Invalid selection. Please choose an option.");
                console.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            console.PrintMainMenu(tenmoApiService.Username);
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {

                PrintCurrentBalance();
              
            }

            if (menuSelection == 2)
            {
                // View your past transfers
            }

            if (menuSelection == 3)
            {
                // View your pending requests
            }

            if (menuSelection == 4)
            {
                // Send TE bucks
                GetUsers();
                Console.WriteLine();
                Transfer transfer = PromptForUserIdAndAmount();
                tenmoApiService.SendTransfer(transfer);

                
                

            }

            if (menuSelection == 5)
            {
                // Request TE bucks
            }

            if (menuSelection == 6)
            {
                // Log out
                tenmoApiService.Logout();
                console.PrintSuccess("You are now logged out");
            }

            return true;    // Keep the main menu loop going
        }

        private void Login()
        {
            LoginUser loginUser = console.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = tenmoApiService.Login(loginUser);
                if (user == null)
                {
                    console.PrintError("Login failed.");
                }
                else
                {
                    console.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console.PrintError("Login failed.");
            }
            console.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = console.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = tenmoApiService.Register(registerUser);
                if (isRegistered)
                {
                    console.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console.PrintError("Registration was unsuccessful.");
            }
            console.Pause();
        }

        private void PrintCurrentBalance()
        {

           decimal balance = tenmoApiService.GetBalanceByUsername();
            Console.WriteLine($"The current Balance is:{balance:C}");
            console.Pause();

        }

        private void GetUsers()

        {
            List<ApiUser> users = tenmoApiService.GetUsers();
            Console.WriteLine($"__________USERS__________");
            
            const int margin = -10;
            string nameColumn = "id";
            string usernameColumn = "Username";
            Console.WriteLine($"{nameColumn, margin} | { usernameColumn, margin}");
            Console.WriteLine($"_________________________"); 
            foreach (ApiUser user in users)
            {
                Console.WriteLine($"{user.UserId,margin} | {user.Username,margin}");
            }
            Console.WriteLine();

            console.Pause();


        }


        private Transfer PromptForUserIdAndAmount()
        {

            //Console.WriteLine($"Id of the User to send funds to: ");

            int userId = console.PromptForInteger("Id of the User to send funds to", int.MinValue, int.MaxValue);
            

            //int userId = Convert.ToInt32(Console.ReadLine());

            if (userId == tenmoApiService.UserId)
            {
                console.PrintError("Cannot send funds to self");
                console.Pause();
                return null;    
                
            }

           else if (!IsUserInList(userId))
            {
                console.PrintError("user not available. PLease enter an existing user.");
                console.Pause();
                return null;

            }


            
            Console.WriteLine($"Enter the amount to send: ");
            Console.WriteLine();
            decimal amount = Convert.ToDecimal(Console.ReadLine());

               if (amount < 0)
                {
                    console.PrintError("Cannot send a nonzero amount.");
                    console.Pause();
                    return null;
                }

               else if(amount > tenmoApiService.GetBalanceByUsername())
                {
                    console.PrintError("Cannot send funds greater than current balance.");
                    console.Pause();
                    return null;

                }

               else
                {

               

            Transfer transfer = new Transfer();
            transfer.Account_To = userId;
            transfer.Amount = amount;
            transfer.Account_From = tenmoApiService.UserId;
            
            return transfer;

                }

            }


        private bool IsUserInList(int userId)
        {

           List<ApiUser> currentUsers = tenmoApiService.GetUsers();

            bool isInList = false;
           
            foreach (ApiUser user in currentUsers)
            {
                if (user.UserId == userId)
                {
                    isInList = true;

                }

            }

            return isInList;


        }

       

     
    }
}
