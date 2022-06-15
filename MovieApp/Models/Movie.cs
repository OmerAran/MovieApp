using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
	public class Movie
	{

		
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public int GenreIdv { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

	}
}

