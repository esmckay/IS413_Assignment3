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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        //Post for the movieData page
        [HttpPost("movieData")]
        public IActionResult movieData(MovieResponse movieInfo)
        {//Make sure that the inputs are valid
            if (ModelState.IsValid)
            {   
                //Add the movie to the list
                tempStorage.AddMovie(movieInfo);
                //return confirmation page
                return View("Confirmation", movieInfo);
            }
            else
            {
                //return back to the same page if not all required inputs are enetered
                return View();
            }
           
        }

        //Podcase page
        public IActionResult podcasts()
        {
            return View();
        }

        //Movie List page
        public IActionResult MovieList()
        {
            return View(tempStorage.Movies);
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
