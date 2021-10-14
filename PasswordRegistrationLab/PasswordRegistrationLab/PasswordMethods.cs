using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PasswordRegistrationLab
{
    class PasswordMethods
    {

        public static string GetValidPassword()
        {
            string password;
            bool passwordCriteriaMet = false;

            password = Program.GetInput("\nEnter password: ");
            while (!passwordCriteriaMet)
            {
                passwordCriteriaMet = ValidatePassword(password);
                if (!passwordCriteriaMet)
                {
                    Console.WriteLine("Let's Try Again...");
                    password = Program.GetInput("Enter Password: ");
                }
            }

            return password;
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
            if (!(userEntry.Contains('!') || userEntry.Contains('@') || userEntry.Contains('#') || userEntry.Contains('$') || userEntry.Contains('%')
                || userEntry.Contains('^') || userEntry.Contains('&') || userEntry.Contains('*')))
            {
                Console.WriteLine("Invalid. Password must contain a special character: !, @, #, $, %, ^, &, or *");
                allCriteriaMet = false;
            }

            //checking for number requirement
            if (!userEntry.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid. Password must contain a number 0-9.");
                allCriteriaMet = false;
            }

            //checking for Uppercase letter requirement
            if (!userEntry.Any(char.IsUpper))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password must contain Uppercase Letter.");
            }

            //checking for lowercase letter requirement 
            if (!userEntry.Any(char.IsLower))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password must contain Lowercase letter.");
            }

            //checking for forbidden words
            if (userEntry.ToLower().Contains("password") || userEntry.ToLower().Contains("rocket"))
            {
                allCriteriaMet = false;
                Console.WriteLine("Invalid. Password cannot contain words password or rocket.");
            }

            //if NOTHING trips the allCriteriaMet bool to turn false, then the input is
            //validated and this returns true. else returns false. 
            return allCriteriaMet;
        }
    }
}
