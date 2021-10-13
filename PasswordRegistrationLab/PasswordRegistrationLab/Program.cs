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
            int dictIndex;
            bool usernameCriteriaMet = false, passwordCriteriaMet = false;
            Dictionary<string, string> userDictionary = new Dictionary<string, string>();
            userDictionary.Add("admin", "P@ssw0rd");
            userDictionary.Add("Test123", "Test@456");

            //first will ask for user's first and last name (will be used in password validation later)
            Console.WriteLine("Welcome to the Password Registration App.");

            while (userChoice != "4")
            {
                //displays main menu and gets user input on what they want to do.
                DisplayMainMenu();
                userChoice = GetInput("Make a selection: ");
                Console.Clear();

                if (userChoice == "1")
                {
                    //this will display criteria, get username input, and validate input until it is valid.
                    DisplayUsernameCriteria();
                    username = GetInput("\nEnter username: ");
                    while (!usernameCriteriaMet)
                    {
                        usernameCriteriaMet = ValidateUsername(username);
                        foreach (KeyValuePair<string, string> user in userDictionary)
                        {
                            //this checks to see if username exists in database, if it does, flips criteria back to false.
                            if (username == user.Key)
                            {
                                Console.WriteLine($"Invalid. Username {username} already exists in database.");
                                usernameCriteriaMet = false;
                            }
                        }
                        if (!usernameCriteriaMet)
                        {
                            Console.WriteLine("Let's Try Again...");
                            username = GetInput("Enter username: ");

                        }

                    }

                    //this will display password criteria, get password input, and validate input until valid. 
                    DisplayPasswordCriteria();
                    password = GetInput("\nEnter password: ");
                    while (!passwordCriteriaMet)
                    {
                        passwordCriteriaMet = ValidatePassword(password);
                        if (!passwordCriteriaMet)
                        {
                            Console.WriteLine("Let's Try Again...");
                            password = GetInput("Enter Password: ");
                        }
                    }

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
                        Console.WriteLine("WELCOME BACK USER!");
                        Console.WriteLine("Press Any Key to Continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Error, invalid username or password.");
                    }
                }

                else if(userChoice == "3")
                {
                    Console.WriteLine("WARNING...ADMIN ONLY!");
                    username = GetInput("Enter your username: ");
                    password = GetInput("Enter your password: ");

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


        //this method displays the username criteria to the user. 
        public static void DisplayPasswordCriteria()
        {
            Console.WriteLine("\nPlease Enter a new password, here are your constraints:");
            Console.WriteLine("Must contain at least one lowercase letter.");
            Console.WriteLine("Must contain at least one upper case letter.");
            Console.WriteLine("Must contain at least one number.");
            Console.WriteLine("Must contain one special character: !, @, #, $, %, ^, &, *");
            Console.WriteLine("Must be minimum 7 characters, maximum 12 characters.");
            Console.WriteLine("Must not contain: the word password or company name (Rocket).");
        }

        //method will display the password criteria to the user. 
        public static void DisplayUsernameCriteria()
        {
            Console.WriteLine("\nPlease Enter a username, here are your constraints:");
            Console.WriteLine("Must contain both letters and numbers.");
            Console.WriteLine("Must have at least 5 letters.");
            Console.WriteLine("Must be at minimum 7 characters, maximum 12 characters");
            Console.WriteLine("Must not contain words Circus, Rocket, or DevBuild");
        }

        //this method will get sent a string prompt and return a string as user input.
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine();

            return answer; 
        }


        //this method will be used to validate the password entry from the user
        //to make sure it is in line with all requirements
        public static bool ValidatePassword(string userEntry)
        {
            bool allCriteriaMet = true;

            //checking for minimum length requirement
            if (userEntry.Length < 7)
            {
                Console.WriteLine("Invalid. Password must contain at least 7 characters.");
                allCriteriaMet = false;
            }

            //checking for max length requirement
            if (userEntry.Length > 12)
            {
                Console.WriteLine("Invalid. Password must contain maximum 12 characters.");
                allCriteriaMet = false;
            }
            
            //checking for special character requirement
            if(!(userEntry.Contains('!') || userEntry.Contains('@') || userEntry.Contains('#') || userEntry.Contains('$') || userEntry.Contains('%') 
                || userEntry.Contains('^') || userEntry.Contains('&') || userEntry.Contains('*'))) {
                Console.WriteLine("Invalid. Password must contain a special character: !, @, #, $, %, ^, &, or *");
                allCriteriaMet = false;
            }

            //checking for number requirement
            if(!userEntry.Any(char.IsDigit)) {
                Console.WriteLine("Invalid. Password must contain a number 0-9.");
                allCriteriaMet = false;
            }

            //checking for Uppercase letter requirement
            if(!userEntry.Any(char.IsUpper))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password must contain Uppercase Letter.");
            }

            //checking for lowercase letter requirement 
            if(!userEntry.Any(char.IsLower))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password must contain Lowercase letter.");
            }

            if(userEntry.ToLower().Contains("password") || userEntry.ToLower().Contains("rocket"))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password cannot contain words password or rocket.");
            }

            //if NOTHING trips the allCriteriaMet bool to turn false, then the input is
            //validated and this returns true. else returns false. 
            if (allCriteriaMet)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //this method will be used to validate the username entry to make sure it 
        //follows the requirements.
        public static bool ValidateUsername(string userEntry)
        {
            bool allCriteriaMet = true;
            int letterCount = 0;

            //checking for minimum length requirement
            if (userEntry.Length < 7)
            {
                Console.WriteLine("Invalid. Username must contain at least 7 characters.");
                allCriteriaMet = false;
            }

            //checking for max length requirement
            if (userEntry.Length > 12)
            {
                Console.WriteLine("Invalid. Username must contain maximum 12 characters.");
                allCriteriaMet = false;
            }

            //checking for number requirement
            if (!userEntry.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid. Username must contain a number 0-9.");
                allCriteriaMet = false;
            }

            //checking for at least 5 letters requirement
            foreach (char c in userEntry)
            {
                if (char.IsLetter(c)) 
                {
                    letterCount++;
                    //runs through a loop to count how many letters the username has
                }
            }
            if(letterCount < 5)
            {
                Console.WriteLine("Invalid, username must contain at least 5 letters.");
                allCriteriaMet = false;
            }

            if (userEntry.ToLower().Contains("circus") || userEntry.ToLower().Contains("rocket") || userEntry.ToLower().Contains("devbuild"))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password cannot contain words password or rocket.");
            }


            //if NOTHING has tripped the allCriteriaMet bool to turn false, 
            //that means the input is valid, and returns true. otherwise, returns false.
            if (allCriteriaMet)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //method to display the main menu to the user to select from. 
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. New User.");
            Console.WriteLine("2. Existing User Login");
            Console.WriteLine("3. ADMIN ONLY: View All Users");
            Console.WriteLine("4. Exit");
        }
    }
}
