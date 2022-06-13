using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

		public async Task<List<Movie>> GetAll()
		{
			return await _context.Set<Movie>().ToListAsync();
		}
	}
}

