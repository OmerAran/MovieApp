using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure;
using MovieApp.Models;

namespace MovieApp.Controllers
{
	public class LoginController : Controller
	{


		MovieAppContext context = new MovieAppContext();

		public LoginController(MovieAppContext _context)
        {
			context = _context;
        }

		

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}



		[AllowAnonymous]
		[HttpPost] 
		public async Task<IActionResult> Index(Admin admin)
		{
			
			var data = context.Admins.FirstOrDefault(x => x.Nickname ==
			admin.Nickname && x.Password == admin.Password);

			if (data != null)
			{

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, admin.Nickname)
				};

				var userIdentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index","Home");
			}

			return View();
		}


        [HttpGet]
		public async Task<IActionResult> LogOut()
        {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
        }
	}
}



