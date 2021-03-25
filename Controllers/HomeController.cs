using JoelHilton_Elijah_McKay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHilton_Elijah_McKay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDBContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get for the movieData page
        [HttpGet("movieData")]
        public IActionResult movieData()
        {
            return View();
        }

        //Post for the movieData page. Sends them to a confirmation page if the input is valid, if not, goes back to the same page.
        [HttpPost("movieData")]
        public IActionResult movieData(MovieResponse movieInfo)
        {
            if (ModelState.IsValid)
            {   
                _context.Movies.Add(movieInfo);

                _context.SaveChanges();

                return View("Confirmation", movieInfo);
            }
            else
            {
                //return back to the same page if not all required inputs are enetered
                return View();
            }
           
        }

        //Podcast page
        public IActionResult podcasts()
        {
            return View();
        }

        //Movie List page
        public IActionResult MovieList()
        {
            return View(_context.Movies.Where(m => m.Title != "Independence Day"));
        }

        //go to the edit movie page for the movie with the id that we pass in
        [HttpPost]
        public IActionResult EditMovie(int movieid)
        {
            var EditedMovie = _context.Movies.Where(m => m.MovieID == movieid).FirstOrDefault();

            return View(EditedMovie);
        }

        //save the changes to the database after they've been updated
        [HttpPost]
        public IActionResult SaveChanges(MovieResponse m, int movieid)
        {
            //match up the movie ids 
            var UpdatedMovie = _context.Movies.Where(m => m.MovieID == movieid).FirstOrDefault();

            //makes sure the input is valid
            if (ModelState.IsValid)
            {
                
                UpdatedMovie.Title = m.Title;
                UpdatedMovie.Category = m.Category;
                UpdatedMovie.Year = m.Year;
                UpdatedMovie.Director = m.Director;
                UpdatedMovie.Rating = m.Rating;
                UpdatedMovie.Edited = m.Edited;
                UpdatedMovie.LentTO = m.LentTO;
                UpdatedMovie.Notes = m.Notes;

                
                _context.SaveChanges();

                
                return View("MovieList", _context.Movies.Where(m => m.Title != "Independence Day"));
            }

            
            return View("EditMovie", m);
        }

        //delete the database by matching up the movie ids and then saving the changes to the database
        [HttpPost]
        public IActionResult DeleteMovie(int movieid)
        {
            
            var MovieToDelete = _context.Movies.Where(m => m.MovieID == movieid).FirstOrDefault();

            _context.Remove(MovieToDelete);
            _context.SaveChanges();

            return View("MovieList", _context.Movies.Where(m => m.Title != "Independence Day"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
