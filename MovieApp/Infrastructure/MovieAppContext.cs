using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Infrastructure
{
	public class MovieAppContext : DbContext
	{
        public MovieAppContext()
        {
        }

        public MovieAppContext(DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}

