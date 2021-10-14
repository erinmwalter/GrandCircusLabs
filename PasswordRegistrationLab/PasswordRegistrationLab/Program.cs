using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordRegistrationLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string username, password, userChoice = "0";
            Dictionary<string, string> userDictionary = new Dictionary<string, string>();
            //added a "admin" and a dummy username for testing purposes to the dictionary.
            userDictionary.Add("admin", "P@ssw0rd");
            userDictionary.Add("Test123", "Test@456");

            
            Console.WriteLine("Welcome to the Password Registration App.");

            while (userChoice != "4")
            {
                //displays main menu and gets user input on what they want to do.
                AllDisplays.DisplayMainMenu();
                userChoice = GetInput("Make a selection: ");
                Console.Clear();

                //based on user choice will execute either branches 1, 2, 3, 4, or "invalid input"
                if (userChoice == "1")
                {
                    //this will display criteria, get username input, and validate input
                    AllDisplays.DisplayUsernameCriteria();
                    username = UsernameMethods.GetValidUsername(userDictionary.Keys.ToList());

                    //this will display password criteria, get password input, and validate input
                    AllDisplays.DisplayPasswordCriteria();
                    password = PasswordMethods.GetValidPassword();

                    //now that everything is valid and username is confirmed to be unique, will add to the dictionary
                    userDictionary.Add(username, password);
                }

                //this choice allows user to "login" entering a username and password. will only let them login if the
                //username is found, and then if found the password entry matches the value of that dictionary item.
                else if (userChoice == "2")
                {
                    username = GetInput("Enter your username: ");
                    password = GetInput("Enter your password: ");

                    if(userDictionary.ContainsKey(username) && (userDictionary.Keys.ToList().IndexOf(username) == userDictionary.Values.ToList().IndexOf(password)))
                    {
                        AllDisplays.DisplaySuccessfulLoginScreen();
                    }
                    else
                    {
                        Console.WriteLine("Error, invalid username or password.");
                    }
                }

                else if(userChoice == "3")
                {
                    Console.WriteLine("WARNING...ADMIN ONLY!");
                    username = GetInput("Enter admin username: ");
                    password = GetInput("Enter admin password: ");

                    if (username == "admin" && password == "P@ssw0rd")
                    {
                        //this is ONLY for testing purposes, iterating through dictionary to make sure values are being added:
                        foreach (KeyValuePair<string, string> user in userDictionary)
                        {
                            Console.WriteLine($"Username: {user.Key}, Password: {user.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, Admin Username and Password Incorrect, returning to main menu.");
                    }
                }

                else if (userChoice == "4")
                {
                    Console.WriteLine("Program Exiting, Goodbye");
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid Selection. Try Again.");
                }

            }

        }

        //this method will get sent a string prompt and return a string as user input.
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine();

            return answer; 
        }


    }
}
