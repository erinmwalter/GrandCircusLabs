using System;
using System.Collections.Generic;
using System.Text;

namespace MovieListApp
{
    //each movie object has a name (title) and genre (category)
    class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }

        //constructor
        public Movie(string Name, string Genre)
        {
            this.Name = Name;
            this.Genre = Genre;
        }
    }
}
