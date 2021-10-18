using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieListApp
{
    class MovieList
    {
        public List<Movie> movies { get; set; } = new List<Movie>();

        //constructor, adds 10 movies to list when movielist initialized
        public MovieList()
        {
            movies.Add(new Movie("Toy Story", "Animated"));
            movies.Add(new Movie("Star Wars", "Sci-Fi"));
            movies.Add(new Movie("The Conjuring", "Horror"));
            movies.Add(new Movie("Aladdin", "Animated"));
            movies.Add(new Movie("Halloween", "Horror"));
            movies.Add(new Movie("Black Panther", "Drama"));
            movies.Add(new Movie("Mission Impossible", "Drama"));
            movies.Add(new Movie("The Ring", "Horror"));
            movies.Add(new Movie("Alien", "Sci-Fi"));
            movies.Add(new Movie("E.T.", "Sci-Fi"));
            movies.Add(new Movie("Lilo and Stitch", "Animated"));
            movies.Add(new Movie("Silver Linings Playbook", "Drama"));

        }

        //method to display the list in alphabetical order
        public void DisplayAlphabeticalList()
        {
            List<Movie> alphabeticalMovies = movies.OrderBy(x => x.Name).ToList();

            Console.WriteLine("Current Movie List:");
            for (int i = 0; i < alphabeticalMovies.Count; i++)
            {
                Console.WriteLine($"{alphabeticalMovies[i].Name}, Genre: {alphabeticalMovies[i].Genre}");
            }
        }

        //returns number of movies in list
        public int GetMovieCount()
        {
            return movies.Count;
        }

        //gets user input
        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        //method displays by genre after prompting user for a specific genre. 
        public void DisplayByGenre()
        {
            List<string> genreList = new List<string>();
            bool goodInput = false;
            int genre = 0;
            //this loop looks through all genres and adds them to the menu for user
            //to choose from.
            foreach (Movie movie in movies)
            {
                if (!genreList.Contains(movie.Genre))
                {
                    genreList.Add(movie.Genre);
                }
            }
            //writes out menu based on the list that was just created of genre options.
            Console.WriteLine("Genre Menu:");
            for (int i = 0; i < genreList.Count; i++)
            {
                Console.WriteLine($"{i}: {genreList[i]}");
            }

            //added try catch to validate input here
            while (!goodInput)
            {
                string input = GetInput("Enter selection: ");
                try
                {
                    genre = int.Parse(input);
                    Console.WriteLine($"{genreList[genre]} Movies:");
                    foreach (Movie movie in movies)
                    {
                        if (genreList[genre] == movie.Genre)
                        {
                            Console.WriteLine(movie.Name);
                        }
                    }
                    break;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, must be integer. try again. ");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Invalid meu selection, must be between 0 and {genreList.Count-1}");
                    continue;
                }
            }


        }
    }
}
