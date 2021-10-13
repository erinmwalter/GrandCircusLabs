using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordRegistrationLab
{
    class AllDisplays
    {
        //method to display the main menu to the user to select from. 
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. New User.");
            Console.WriteLine("2. Existing User Login");
            Console.WriteLine("3. ADMIN ONLY: View All Users");
            Console.WriteLine("4. Exit");
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

        public static void DisplaySuccessfulLoginScreen()
        {
            Console.WriteLine("WELCOME BACK USER!");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
    }
}
