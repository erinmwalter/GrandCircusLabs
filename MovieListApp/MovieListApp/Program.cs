using System;

namespace MovieListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieList myMovies = new MovieList();
            bool runAgain = true;

            Console.WriteLine("Welcome to the Movie List App.");
            Console.WriteLine($"There are {myMovies.GetMovieCount()} movies on this list.\n");

            while (runAgain)
            {
                //main menu
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View movies by Genre.");
                Console.WriteLine("2. View Entire List.");
                Console.WriteLine("3. Exit.");

                string userChoice = GetInput("What would you like to do: ");
                if (userChoice == "1")
                {
                    //asks user for genre and displays by genre
                    myMovies.DisplayByGenre();
                }
                else if (userChoice == "2")
                {
                    //displays entire alphabetized list
                    myMovies.DisplayAlphabeticalList();
                }
                else if (userChoice == "3")
                {
                    //program exit so breaks from loop
                    break;
                }
                else
                {
                    //error catching.
                    Console.WriteLine("Invalid Input, try again.");
                    continue;
                }

                runAgain = Continue();
            }
            Console.WriteLine("Goodbye");
        }

        //asks user if they would like to run program again
        public static bool Continue()
        {
            Console.WriteLine("Would you like to go again? (y/n): ");
            string answer = Console.ReadLine().Trim().ToLower();

            if(answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                return Continue();
            }
        }

        //gets user input
        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
