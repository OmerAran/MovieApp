using System.Collections.Generic;
using System.Linq;
using MovieApp.Infrastructure;
using MovieApp.Models;

namespace MovieApp.Repository
{
	public class MovieRepository  // HENUZ KULLANMIYORUM AMA KULLANCAĞIM.
	{
		private readonly MovieAppContext _context;
		


		public MovieRepository(MovieAppContext context)
		{
			_context = context;
		}




		public void Add(Movie movie)
        {
			_context.Movies.Add(movie);
			_context.SaveChanges();
        }



		public void Delete(Movie movie)
		{
			_context.Movies.Remove(movie);
			_context.SaveChanges();
		}




		public void Edit(Movie movie)
		{
			_context.Movies.Update(movie);
			_context.SaveChanges();
		}




		public List<Movie> GetAllMovies()
        {
			return _context.Movies.ToList();
        }




		public  Movie GetOneMovie(int id)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            return movie;

		}
	}
}

