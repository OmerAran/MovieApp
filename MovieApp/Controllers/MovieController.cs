using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure;
using MovieApp.Models;
using MovieApp.Repository;

namespace MovieApp.Controllers
{
	public class MovieController : Controller
	{

		private readonly MovieAppContext _context;
		private  MovieRepository _repository;


		public MovieController(MovieAppContext context)
        {
			_context = context;
			_repository = new MovieRepository(_context);
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			var movies = _repository.GetAllMovies();
			return View(movies);
		}



		//[Authorize]
		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var movie = _repository.GetOneMovie(id);
            return View(movie);
		}

		[AllowAnonymous]
		public IActionResult Add(int id)
		{

			return View(_context.Movies.Find(id));
		}


		public IActionResult Delete(int id)
		{
			var movie = _repository.GetOneMovie(id);
			_repository.Delete(movie);
			return View();
		}


		public IActionResult Update(int id)
		{
			//BAKILACAK
			var movie = _repository.GetOneMovie(id);
			_repository.Edit(movie);
			
			return View();
		}


		


		[HttpGet]
		public IActionResult New()
		{
			var movie = new Movie();
			return View(movie);
		}


		[HttpPost]
		public IActionResult New(Movie movie)
		{
			_repository.Add(movie);
			return RedirectToAction("Index","Home");   //RedirectToAction("actionname","routevalue")
			// RedirectToAction("Index") ise Movie/Index ' e götürür.

		}
		

		

	}
}

