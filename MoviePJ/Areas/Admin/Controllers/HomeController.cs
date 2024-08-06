using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using MoviePJ.WebConfig.Consts;

namespace MoviePJ.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = AppConst.COOKIES_AUTH)]
	public class HomeController : AppControllerBase
    {
		private readonly ILogger<HomeController> _logger;

		public HomeController(MoviePJ_DBContext db, ILogger<HomeController> logger) : base(db)
        {
			_logger = logger;
		}

		public IActionResult Index()
        {
			ViewBag.CountGenre = _db.AppGenres.Where(m => m.DeletedDate == null).Count();
			ViewBag.CountFilm = _db.AppFilms.Where(m => m.DeletedDate == null).Count();
			ViewBag.CountUser = _db.AppUser.Where(m => m.DeletedDate == null && !m.Username.Contains(CurrentUsername) && m.AppRoleId != AppConst.ROLE_ADMINISTRATOR_ID).Count();
			ViewBag.CountActor = _db.AppActors.Where(m => m.DeletedDate == null).Count();
			ViewBag.CountFilmmaker = _db.AppMaker.Where(m => m.DeletedDate == null).Count();
			ViewBag.CountStudio = _db.AppStudio.Where(m => m.DeletedDate == null).Count();

			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			return View(statusCode.ToString().Trim());
		}
	}
}
