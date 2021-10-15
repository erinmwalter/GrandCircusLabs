using System;

namespace ATMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM myATM = new ATM();
            string userChoice = "0";

            Console.WriteLine("Welcome to the ATM App.");

            //users can choose from the main menu
            while (userChoice != "3")
            {
                DisplayMainMenu();
                userChoice = GetInput("Make Your Selection: ");

                if(userChoice == "1")
                {
                    //register a new account selected
                    myATM.RegisterAccount();
                }
                else if (userChoice == "2")
                {
                    //login selected, prompt for username and password
                    //and send that to the ATM for validation
                    string username = GetInput("Enter username: ");
                    string password = GetInput("Enter password: ");
                    myATM.Login(username, password);
                }
                else if (userChoice == "3")
                {
                    //exit
                    Console.WriteLine("Program Exit Selected. Goodbye.");
                    break;
                }
                else
                {
                    //validation in case something not on menu entered
                    Console.WriteLine("Invalid entry, please try again.");
                }
            }
        }

        //method displays main menu and options to the user
        public static void DisplayMainMenu()
        {
            Console.WriteLine("ATM Menu:");
            Console.WriteLine("1. Register New User.");
            Console.WriteLine("2. Existing User Login.");
            Console.WriteLine("3. Exit.");
        }

        //gets input from the user
        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
