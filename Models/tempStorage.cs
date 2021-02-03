using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//I don't understand this yet but this is how we get it into a list
namespace JoelHilton_Elijah_McKay.Models
{
    public static class tempStorage
    {
        private static List<MovieResponse> movies = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> Movies => movies;

        public static void AddMovie(MovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
