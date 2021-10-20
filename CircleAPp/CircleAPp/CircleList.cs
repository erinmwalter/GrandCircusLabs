using System;
using System.Collections.Generic;
using System.Text;

namespace CircleApp
{
    class CircleList
    {
        public List<Circle> circleList = new List<Circle>();

        //method to display the circle list to the screen
        public void DisplayCircleList()
        {
            Console.WriteLine($"You Entered {circleList.Count} circles.");
            Console.WriteLine($"Here they are:\n");
            for (int i = 0; i < circleList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {circleList[i]}");
            }
        }

        //method to add circle to list
        public void AddCircle(Circle circle)
        {
            circleList.Add(circle);
        }

        //this method validates the user input to ensure it's a valid positive double value
        public double GetValidInput(string prompt)
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
