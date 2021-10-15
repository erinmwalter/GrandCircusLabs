using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApp
{
    class ATM
    {
        private List<Account> accountList = new List<Account>();

        //method in the ATM object to allow new account registration
        public void RegisterAccount()
        {
            Console.WriteLine("Register New User:");
            string username = Program.GetInput("Enter Username: ");
            string password = Program.GetInput("Enter Password: ");
            if(!double.TryParse(Program.GetInput("Enter Initial Deposit: "), out double balance) || balance < 0)
            {
                Console.WriteLine("Invalid balance input entered. Defaulting to zero.");
                balance = 0;
            }

            Account newAccount = new Account(username, password, balance);

            accountList.Add(newAccount); //adds new list item to ATM object
        }

        //login method, matches uername and password to existing items in list
        public void Login(string username, string password)
        {
            bool foundAccount = false;
            foreach (Account account in accountList)
            {
                if (account.Name == username && account.Password == password)
                {
                    Console.WriteLine("Login Successful.");
                    Console.WriteLine($"Welcome, {username}.");
                    foundAccount = true;
                    account.AccountActions();
                    break;
                }
            }
            if(!foundAccount)
            {
                Console.WriteLine("Login unsuccessful. Invalid username or password. Try again. ");
            }
        }



    }
}
