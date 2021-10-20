using System;
using System.Collections.Generic;

namespace CircleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CircleList circleList = new CircleList();
            bool runAgain = true;

            Console.WriteLine("Welcome to the Circle App.");

            //loops and adds circles until the user wants to stop entering
            while (runAgain) 
            {
                double radius = circleList.GetValidInput("Enter Circle Radius: ");
                Circle circle = new Circle(radius);
                circleList.AddCircle(circle);
                runAgain = Continue("Enter Another Circle? (y/n): ");
            }

            //once user is done entering circles this will display each circle info in list.
            Console.Clear();
            circleList.DisplayCircleList();
            Console.WriteLine("\nGoodbye!");

        }

        //continue method that prompts user if they want to go on
        public static bool Continue(string prompt)
        {
            Console.Write(prompt);
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



    }
}
