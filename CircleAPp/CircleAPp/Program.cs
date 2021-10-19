using System;
using System.Collections.Generic;

namespace CircleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> circleList = new List<Circle>();
            bool runAgain = true;

            Console.WriteLine("Welcome to the Circle App.");

            //loops and adds circles until the user wants to stop entering
            while (runAgain) 
            {
                double radius = GetValidInput("Enter Circle Radius: ");
                Circle circle = new Circle(radius);
                circleList.Add(circle);
                runAgain = Continue("Enter Another Circle? (y/n): ");
            }

            //once user is done entering circles this will display each circle info in list.
            Console.Clear();
            Console.WriteLine($"You Entered {circleList.Count} circles.");
            Console.WriteLine($"Here they are:\n");
            for (int i = 0; i < circleList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {circleList[i]}");
            }
            Console.WriteLine("\nGoodbye!");

        }

        //continue method that prompts user if they want to go on
        public static bool Continue(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand, try again.");
                return Continue(prompt);
            }
        }

        //this method validates the user input to ensure it's a valid positive double value
        public static double GetValidInput(string prompt)
        {
            bool goodInput = false;
            double radius = 0;
            while (!goodInput)
            {
                try
                {
                    Console.Write(prompt);
                    radius = double.Parse(Console.ReadLine());
                    if (radius <= 0)
                    {
                        throw new InvalidNegativeEntry();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, must be a double-type value.");
                    continue;
                }
                catch (InvalidNegativeEntry e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            return radius;
            

        }

        //custom exception to throw if input invalid. 
        public class InvalidNegativeEntry : Exception
        {
            public override string Message
            {
                get
                {
                    return "Radius Must be > 0. Try Again.";
                }
            }
        }

    }
}
