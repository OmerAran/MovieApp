using System;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure;

namespace MovieApp.Controllers
{
	public class MovieController : Controller
	{

		private readonly MovieAppContext _context;

		public MovieController(MovieAppContext context)
        {
			_context = context;
        }
		

		public IActionResult Details(int id)
		{
			 
            return View(_context.Movies.Find(id));
		}


		public IActionResult List()
		{
			return View();
		}



	}
}

