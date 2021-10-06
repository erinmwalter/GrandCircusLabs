using System;

namespace NumberAnalyzerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userNumber;
            string userName;
            char runAgain = 'y';

            //welcome user to app and get user's name and number input
            Console.WriteLine("Welcome To the Number Analyzer App!");
            Console.Write("What is your name? ");
            userName = Console.ReadLine();
            Console.WriteLine($"Welcome, {userName}!");

            //prompts user to enter a number between 1 and 100
            while (runAgain == 'y')
            {
                Console.Write("Enter an Integer between 1 and 100: ");
                int.TryParse(Console.ReadLine(), out userNumber);

                //input validation, will continue to prompt user to enter a different number
                //if number not between 1 and 100
                while (userNumber < 1 || userNumber > 100)
                {
                    Console.WriteLine($"I'm sorry, {userName}, {userNumber} is not a valid input.");
                    Console.Write("Please enter an integer between 1 and 100: ");
                    userNumber = int.Parse(Console.ReadLine());
                }

                //sends number to be analyzed
                AnalyzeNumber(userNumber);

                //asks user if they would like to run again
                Console.Write($"{userName}, would you like to enter another number? y/n: ");
                runAgain = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nProgram Exited. Goodbye!");




        }

        //this method will analyze the number through a series of if/else statements
        //and generate output to console depending on the number's value
        public static void AnalyzeNumber(int number)
        {
            if(number % 2 == 0 && (number >= 2 && number <= 25))
            {
                Console.WriteLine("Even and less than 25.");
            }
            else if (number % 2 == 0 && (number >= 26 && number <= 60))
            {
                Console.WriteLine("Even.");
            }
            else if (number % 2 == 0 && number > 60)
            {
                Console.WriteLine($"{number}. Even.");
            }
            else
            {
                Console.WriteLine($"{number}. Odd.");
            }

            //Lab Summary Question: this "ELSE" statement above covers all odd numbers.
            //the first condition was if the number is ODD at all it prints the number and odd.
            //the last condition said if the number > 60 and ODD it prints the number and odd.
            //since these can be covered in one case and because even numbers 1-100 were accounted
            //for in all other cases, I threw this into the "else" portion instead of making additional if else
            //statements for these. 
        }
    }
}
