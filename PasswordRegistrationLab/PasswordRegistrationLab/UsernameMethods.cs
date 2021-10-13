using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PasswordRegistrationLab
{
    class UsernameMethods
    {
        public static string GetValidUsername(List<string> usernames)
        {
            bool usernameCriteriaMet = false;
            string username;

            username = Program.GetInput("\nEnter username: ");

            while (!usernameCriteriaMet)
            {
                usernameCriteriaMet = ValidateUsername(username);
                foreach (string user in usernames)
                {
                    //this checks to see if username exists in database, if it does, flips criteria back to false.
                    if (username == user)
                    {
                        Console.WriteLine($"Invalid. Username {username} already exists in database.");
                        usernameCriteriaMet = false;
                    }
                }
                if (!usernameCriteriaMet)
                {
                    Console.WriteLine("Let's Try Again...");
                    username = Program.GetInput("Enter username: ");

                }

            }

            return username;
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
            if (letterCount < 5)
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
            return allCriteriaMet;

        }
    }
}
