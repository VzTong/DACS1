using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.ViewModels.Film;
using System.Diagnostics;

namespace MoviePJ.Controllers
{
	public class HomeController : MoviePJControllerBase
	{
		public HomeController(MoviePJ_DBContext db) : base(db)
		{
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.movieAdventure = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_ADVENTURE))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.movieDrama = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_DRAMA))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.movieScience_Fiction = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_SCIENCE_FICTION))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.movieThriller = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_THRILLER))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.animeShojo = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_SHOJO))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.animeKodomomuke = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_KODOMOMUKE))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.animeMecha = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_MECHA))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			ViewBag.animeIsekai = _db.AppFilms
								.Where(f => f.AppGenresFilms.
											Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_ISEKAI))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.ToList();

			var fslider = await _db.AppFilms
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.Select(f => new FilmVM
								{
									Id = f.Id,
									Name = f.Name,
									AnotherName = f.AnotherName,
									Cover = f.Cover,
									Country = f.Country,
									Desc = f.Desc,
									Slug = f.Slug,
									Language = f.Language,
									EpisodeCount = f.EpisodeCount,
									ReleaseYear = f.ReleaseYear,
									Time = f.Time,
									TrailerPath = f.TrailerPath,
									StatusName = f.AppStatus.Name,
									GenresName = _db.AppGenres
												.Where(g => g.AppGenresFilms.Any(gf => gf.GenresId == g.Id) && g.AppGenresFilms.Any(c => c.FilmId == f.Id))
												.Select(f => f.Name).Distinct().ToList(),
								})
								.Take(3)
								.ToListAsync();

			ViewBag.Action = _db.AppFilms
								.Where(f => f.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.FILM_ACTION))
								.Where(f => f.DeletedDate == null && f.IsActive == true)
								.OrderByDescending(f => f.DisplayOrder)
								.ThenByDescending(f => f.Id)
								.Take(6);

			ViewBag.Actor = _db.AppActors
								.OrderByDescending(f => f.Id)
								.Where(f => f.DeletedDate == null)
								.Take(3);

			return View(fslider);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			return View(statusCode.ToString().Trim());
		}
	}
}

