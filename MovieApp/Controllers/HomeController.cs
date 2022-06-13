using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Infrastructure;
using MovieApp.Models;
using MovieApp.Repository;

namespace MovieApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly MovieAppContext _context;
       


        public HomeController (MovieAppContext context)
        {
            _context = context;
            
        }




        public IActionResult Index()
        {
           
            return View(_context.Movies);
          
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

