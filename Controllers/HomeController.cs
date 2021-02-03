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

        [HttpGet("movieData")]
        public IActionResult movieData()
        {
            return View();
        }

        [HttpPost("movieData")]
        public IActionResult movieData(MovieResponse movieInfo)
        {
            if (ModelState.IsValid)
            {
                tempStorage.AddMovie(movieInfo);
                return View("Confirmation", movieInfo);
            }
            else
            {
                return View();
            }
           
        }

        public IActionResult podcasts()
        {
            return View();
        }

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
