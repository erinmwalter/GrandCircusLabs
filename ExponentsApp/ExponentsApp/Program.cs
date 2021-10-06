using System;

namespace ExponentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userNumber;
            bool runAgain = true;
            bool isValid;

            Console.WriteLine("Welcome to the Exponents App!");
            Console.WriteLine("Learn your squares and cubes!");

            while (runAgain)
            {
                //gets value from user
                int.TryParse(HelperMethods.GetInput("\nPlease enter a positive integer: "), out userNumber);

                //check for valid input, will only display table if input valid.
                isValid = IsInputValid(userNumber);

                if (isValid)
                {
                    //displays the multiplication table
                    DisplayTable(userNumber);
                }
                //asks user if they want to run again
                runAgain = HelperMethods.Continue();
            }

            Console.WriteLine("Program Exited. Goodbye!");

        }

        //This method will get user input based on prompt
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();

            return userInput;
        }

        //this method is used to determine if user would like to
        //run the program again or end program.
        public static bool Continue()
        {
            string userInput = GetInput("\nWould you like to try again?").ToLower();

            if (userInput == "y")
            {
                return true;
            }
            else if(userInput == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand. Try Again.");
                return Continue();
            }
        }

        //this method will take a value and return squared value
        public static int SquareValue(int value)
        {
            return value * value;
        }

        //this method will take in a value and return cubed value
        public static int CubeValue(int value)
        {
            return value * value * value;
        }

        //this method will be used to display the multiplication table, from 1 to the value
        //that the user has input
        public static void DisplayTable(int value)
        {
            Console.WriteLine("\n          Your Multiplication Table:   ");
            Console.WriteLine("  Number             Squared              Cubed");
            Console.WriteLine("==========         ===========         ==========");

            //this for loop will display each line of the display table, right aligned.
            for (int i = 1; i <= value; i++)
            {
                Console.WriteLine($"{i, 10}{SquareValue(i), 20}{CubeValue(i),19}");
            }
        }

        //this method will test number to make sure it is a valid input
        //per google, the max integer value allowed in C# is 2,147,483,647
        //so the cube root of this number is about 1290.159
        //so the max allowable integer for our purposes is 1290
        public static bool IsInputValid(int value)
        {
            if (value > 1 && value <= 1290)
            {
                return true;
            }
            else
            {
                Console.WriteLine("I'm sorry, your value was not in the allowed range.");
                Console.WriteLine("Number must be between 1 and 1290.");
                return false;
            }
        }
    }
}
