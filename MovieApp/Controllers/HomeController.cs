using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Infrastructure;
using MovieApp.Models;
using MovieApp.Repository;

namespace MovieApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private  MovieAppContext _context;
        private  MovieRepository _repository;


        public HomeController (MovieAppContext context)
        {
            _context = context;
            _repository =  new MovieRepository(_context);
            
        }



      
        public IActionResult Index()
        {
            var movies = _repository.GetAllMovies();
            return View(movies);
          
        }

        
        public IActionResult About()
        {
            return View();
        }

        
        public IActionResult Contact()
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

