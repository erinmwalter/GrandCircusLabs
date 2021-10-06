using System;
using System.Collections.Generic;
using System.Text;

namespace ExponentsApp
{
    class HelperMethods
    {

        //This method will get user input based on prompt
        //user can send it any message as a string "prompt" and get user input
        //in the form of a string.
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();

            return userInput;
        }

        //this method is used to determine if user would like to
        //run the program again or end program,
        //will also validate user input.
        public static bool Continue()
        {
            string userInput = GetInput("\nWould you like to try again?").ToLower();

            if (userInput == "y")
            {
                return true;
            }
            else if (userInput == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand. Try Again.");
                return Continue();
            }
        }


        //this check range helper method will check a range to validate whether
        //the user value is within it or not.
        
        public static bool CheckRange(int min, int max, int valueToCheck)
        {
            if (max > min)
            {
                if (valueToCheck > min && valueToCheck < max)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Warning: Max Value {max} is less than Min Value {min}.");
                return false;
            }
        }


    }
}
