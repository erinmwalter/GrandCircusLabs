using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApp
{
    class Account
    {
        //properties:
        public string Name { get; set; }
        public string Password { get; set; }
        private double Balance { get; set; }

        //constructor
        public Account (string Name, string Password, double Balance=0)
        {
            this.Name = Name;
            this.Password = Password;
            this.Balance = Balance;
        }

        //once logged in will display this sub-menu.

        public void AccountActions()
        {
            string choice = "0";

            while (choice != "4")
            {
                DisplayUserMenu();
                choice = GetInput("Enter your selection: ");
                if (choice == "1")
                {
                    Console.WriteLine("Current Balance: ");
                    Console.WriteLine($"${Balance}");
                }
                else if (choice == "2")
                {
                    Balance += double.Parse(GetInput("Deposit Amount: "));
                }
                else if (choice == "3")
                {
                    double withdrawal = double.Parse(GetInput("Withdrawal Amount:"));
                    if (Balance > withdrawal)
                    {
                        Balance -= withdrawal;
                    }
                    else
                    {
                        Console.WriteLine("Withdrawal amount larger than current balance. Could not withdraw. ");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try Again.");
                    continue;
                }

            }


        }

        //user menu 
        private void DisplayUserMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Check Balance.");
            Console.WriteLine("2. Make Deposit. ");
            Console.WriteLine("3. Make Withdrawal. ");
            Console.WriteLine("4. Logout. ");
        }

        //method to get input.
        private string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }


    }
}
