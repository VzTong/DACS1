using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.ViewModels.Film;
using Newtonsoft.Json;
using System.Drawing;
using X.PagedList;
using static MoviePJ.WebConfig.Consts.VM;

namespace MoviePJ.Controllers
{
	public class FilmController : MoviePJControllerBase
	{
		private const int DEFAULT_PAGE_SIZE = 12;

		public FilmController(MoviePJ_DBContext db) : base(db) { }

		[Route("/movie-grid")]
		public async Task<IActionResult> MovieGrid(int page = 1, int page_size = DEFAULT_PAGE_SIZE)
		{
			ViewBag.movieTotal = _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.Count();

			var data = await _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.ToPagedListAsync(page, page_size);

			return View(data);
		}

		[Route("/movie-list")]
		public async Task<IActionResult> MovieList(int page = 1, int page_size = DEFAULT_PAGE_SIZE)
		{
			ViewBag.movieTotal = _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.Count();

			var data = await _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.MOVIE))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.Select(m => new FilmVM
					{
						Id = m.Id,
						Name = m.Name,
						AnotherName = m.AnotherName,
						Cover = m.Cover,
						Country = m.Country,
						Desc = m.Desc,
						Slug = m.Slug,
						Language = m.Language,
						EpisodeCount = m.EpisodeCount,
						ReleaseYear = m.ReleaseYear,
						Time = m.Time,
						TrailerPath = m.TrailerPath,
						StatusName = m.AppStatus.Name,
						DisplayOrder = m.DisplayOrder,
						GenresName = _db.AppGenres
												.Where(g => g.AppGenresFilms.Any(gf => gf.GenresId == g.Id) && g.AppGenresFilms.Any(f => f.FilmId == m.Id))
												.Select(g => g.Name).Distinct().ToList(),

						Actor = _db.AppActors
								.Where(a => a.AppFilmActors.Any(af => af.AppActorId == a.Id) && a.AppFilmActors.Any(f => f.AppFilmId == m.Id))
								.Select(a => new ActorFilmVM
								{
									Avatar = a.Avatar,
									FullName = a.FullName
								})
								.Distinct()
								.ToList(),

						Filmmaker = _db.AppMaker
								.Where(mk => mk.AppFilmmakers.Any(fm => fm.MakerId == mk.Id) && mk.AppFilmmakers.Any(f => f.FilmId == m.Id))
								.Select(mk => new FilmmakerVM
								{
									Avatar = mk.Avatar,
									FullName = mk.FullName
								})
								.Distinct()
								.ToList(),

						Studio = _db.AppStudio
								.Where(s => s.AppStudioFilms.Any(sf => sf.StudioId == s.Id) && s.AppStudioFilms.Any(f => f.FilmId == m.Id))
								.Select(s => new StudioFilmVM
								{
									Cover = s.Cover,
									Name = s.Name
								})
								.Distinct()
								.ToList()
					})
					.ToPagedListAsync(page, page_size);

			return View(data);
		}

		[Route("/anime-grid")]
		public async Task<IActionResult> AnimeGrid(int page = 1, int page_size = DEFAULT_PAGE_SIZE)
		{
			ViewBag.animeTotal = _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.Count();

			var data = await _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.ToPagedListAsync(page, page_size);

			return View(data);
		}

		[Route("/anime-list")]
		public async Task<IActionResult> AnimeList(int page = 1, int page_size = DEFAULT_PAGE_SIZE)
		{
			ViewBag.animeTotal = _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.Count();

			var data = await _db.AppFilms
					.Where(m => m.AppGenresFilms.Any(gf => gf.GenresId == DB.AppGenresFilm.ANIME))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.Select(m => new FilmVM
					{
						Id = m.Id,
						Name = m.Name,
						AnotherName = m.AnotherName,
						Cover = m.Cover,
						Country = m.Country,
						Desc = m.Desc,
						Slug = m.Slug,
						Language = m.Language,
						EpisodeCount = m.EpisodeCount,
						ReleaseYear = m.ReleaseYear,
						Time = m.Time,
						TrailerPath = m.TrailerPath,
						StatusName = m.AppStatus.Name,
						DisplayOrder = m.DisplayOrder,
						GenresName = _db.AppGenres
												.Where(g => g.AppGenresFilms.Any(gf => gf.GenresId == g.Id) && g.AppGenresFilms.Any(f => f.FilmId == m.Id))
												.Select(g => g.Name).Distinct().ToList(),

						Actor = _db.AppActors
								.Where(a => a.AppFilmActors.Any(af => af.AppActorId == a.Id) && a.AppFilmActors.Any(f => f.AppFilmId == m.Id))
								.Select(a => new ActorFilmVM
								{
									Avatar = a.Avatar,
									FullName = a.FullName
								})
								.Distinct()
								.ToList(),

						Filmmaker = _db.AppMaker
								.Where(mk => mk.AppFilmmakers.Any(fm => fm.MakerId == mk.Id) && mk.AppFilmmakers.Any(f => f.FilmId == m.Id))
								.Select(mk => new FilmmakerVM
								{
									Avatar = mk.Avatar,
									FullName = mk.FullName
								})
								.Distinct()
								.ToList(),

						Studio = _db.AppStudio
								.Where(s => s.AppStudioFilms.Any(sf => sf.StudioId == s.Id) && s.AppStudioFilms.Any(f => f.FilmId == m.Id))
								.Select(s => new StudioFilmVM
								{
									Cover = s.Cover,
									Name = s.Name
								})
								.Distinct()
								.ToList()
					})
					.ToPagedListAsync(page, page_size);

			return View(data);
		}

		[Route("/all-film")]
		public async Task<IActionResult> FilmByGenre(int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			ViewBag.TitleH1 = "All films";

			var data = await _db.AppFilms
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.Select(m => new FilmVM
					{
						Id = m.Id,
						Name = m.Name,
						AnotherName = m.AnotherName,
						Slug = m.Slug,
						Cover = m.Cover,
						DisplayOrder = m.DisplayOrder,
					})
					.ToPagedListAsync(page, size);

			ViewBag.filmsTotal = _db.AppFilms
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.Select(m => new FilmVM
					{
						Id = m.Id,
						Name = m.Name,
						AnotherName = m.AnotherName,
						Slug = m.Slug,
						Cover = m.Cover,
					}).Count();

			return View(data);
		}

		[Route("/films-by-genre/{slug}-{filmid}")]
		public async Task<IActionResult> Index(string slug = "", int filmid = 0, int page = 1, int size = DEFAULT_PAGE_SIZE)
		{
			var genre = await _db.AppGenres
				.Where(f => f.Id == filmid)
				.SingleOrDefaultAsync();

			if (genre == null) return NotFound();

			var listfilmid = new List<int>();
			if (genre.CateLevel == 1)
			{
				listfilmid = await _db.AppGenres
						.Where(ls => ls.ParentCateId.Equals(genre.Id))
						.Select(x => x.Id)
						.ToListAsync();
			}
			else
			{
				listfilmid.Add(genre.Id);
			}

			var films = await _db.AppFilms
					.Where(x => x.AppGenresFilms.Any(ca => ca.GenresId == filmid))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.Select(f => new FilmVM
					{
						Id = f.Id,
						Name = f.Name,
						AnotherName = f.AnotherName,
						Cover = f.Cover,
						Desc = f.Desc,
						Slug = f.Slug,
						DisplayOrder = f.DisplayOrder
					})
					.ToPagedListAsync(page, size);

			ViewBag.FilmGenre = genre;
			ViewBag.filmId = filmid;
			ViewBag.filmTotal = films.Count();

			return View(films);
		}

		public async Task<IActionResult> Search(int page = 1, string keywork = "", int size = DEFAULT_PAGE_SIZE)
		{
			var films = await _db.AppFilms
					.Where(x => x.Name.Contains(keywork) || x.AnotherName.Contains(keywork))
					.Where(f => f.DeletedDate == null && f.IsActive == true)
					.OrderByDescending(f => f.DisplayOrder)
					.ThenByDescending(f => f.Id)
					.Select(f => new FilmVM
					{
						Id = f.Id,
						Name = f.Name,
						AnotherName = f.AnotherName,
						Cover = f.Cover,
						Desc = f.Desc,
						Slug = f.Slug,
						DisplayOrder = f.DisplayOrder
					})
					.ToPagedListAsync(page, size);

			ViewBag.TitleH1 = $"Search results for ⌈ {keywork} ⌋";

			ViewBag.filmsTotal = films.Count();

			return View("FilmByGenre", films);
		}

		[Route("/film-detail/{slug}-{filmId:int}")]
		public async Task<IActionResult> FilmDetail(string slug = "", int filmId = 0)
		{
			if (filmId == 0) return NotFound();

			var dataFilm = await _db.AppFilms
										.Where(f => f.DeletedDate == null && f.IsActive == true)
										.Select(m => new FilmVM
										{
											Id = m.Id,
											Name = m.Name,
											AnotherName = m.AnotherName,
											Cover = m.Cover,
											Country = m.Country,
											Desc = m.Desc,
											Slug = m.Slug,
											Language = m.Language,
											EpisodeCount = m.EpisodeCount,
											ReleaseYear = m.ReleaseYear,
											Time = m.Time,
											TrailerPath = m.TrailerPath,
											StatusName = m.AppStatus.Name,
											DisplayOrder = m.DisplayOrder,

											GenresName = _db.AppGenres
																		.Where(g => g.AppGenresFilms.Any(gf => gf.GenresId == g.Id) && g.AppGenresFilms.Any(f => f.FilmId == m.Id))
																		.Select(g => g.Name).Distinct().ToList(),

											Stars = _db.AppActors
														.Where(a => a.AppFilmActors.Any(af => af.AppActorId == a.Id) && a.AppFilmActors.Any(f => f.AppFilmId == m.Id))
														.Select(a => a.FullName)
														.Distinct()
														.Take(3)
														.ToList(),

											Actor = _db.AppActors
														.Where(a => a.AppFilmActors.Any(af => af.AppActorId == a.Id) && a.AppFilmActors.Any(f => f.AppFilmId == m.Id))
														.Select(a => new ActorFilmVM
														{
															Avatar = a.Avatar,
															FullName = a.FullName
														})
														.Distinct()
														.ToList(),

											Filmmaker = _db.AppMaker
														.Where(mk => mk.AppFilmmakers.Any(fm => fm.MakerId == mk.Id) && mk.AppFilmmakers.Any(f => f.FilmId == m.Id))
														.Select(mk => new FilmmakerVM
														{
															Avatar = mk.Avatar,
															FullName = mk.FullName
														})
														.Distinct()
														.ToList(),

											Studio = _db.AppStudio
														.Where(s => s.AppStudioFilms.Any(sf => sf.StudioId == s.Id) && s.AppStudioFilms.Any(f => f.FilmId == m.Id))
														.Select(s => new StudioFilmVM
														{
															Cover = s.Cover,
															Name = s.Name
														})
														.Distinct()
														.ToList()

										})
										.SingleOrDefaultAsync(s => s.Slug.Equals(slug) && s.Id.Equals(filmId));

			if (dataFilm == null) return NotFound();

			return View(dataFilm);
		}

		[Route("/{slug}-{filmId:int}")]
		//[Route("/film-watching/{slug}-{filmId:int}")]
		public async Task<IActionResult> FilmWatching(string slug = "", int filmId = 0)
		{
			if (filmId == 0) return NotFound();

			var dataFilm = await _db.AppFilms
											.Where(f => f.DeletedDate == null && f.IsActive == true)
											.Select(m => new FilmVM
											{
												Id = m.Id,
												Name = m.Name,
												AnotherName = m.AnotherName,
												Cover = m.Cover,
												Country = m.Country,
												Desc = m.Desc,
												Slug = m.Slug,
												Language = m.Language,
												EpisodeCount = m.EpisodeCount,
												ReleaseYear = m.ReleaseYear,
												Time = m.Time,
												TrailerPath = m.TrailerPath,
												StatusName = m.AppStatus.Name,
												DisplayOrder = m.DisplayOrder,

												Episodes = _db.AppEpisodes
															.Where(e => e.FilmId == m.Id)
															.Select(e => new EpisodeFilmVM
															{
																EpNumber = e.EpNumber,
																Path = e.Path
															})
															.Distinct().ToList()
											})
											.SingleOrDefaultAsync(s => s.Slug.Equals(slug) && s.Id.Equals(filmId));

			if (dataFilm == null) return NotFound();

			SetRecentFilm(filmId);

			return View(dataFilm);
		}

		/// <summary>
		/// Hàm này được sử dụng để quản lý danh sách các film gần đây mà người dùng đã xem hoặc tương tác trên trang web
		/// </summary>
		/// <param name="filmId"></param>
		private void SetRecentFilm(int filmId)
		{
			var key = "RecentFilm";
			var Session = HttpContext.Session;
			var sessionValue = Session.GetString(key);
			var listFilm = new List<int>();

			if (sessionValue.IsNullOrEmpty())
			{
				listFilm.Add(filmId);
			}

			else
			{
				listFilm = JsonConvert.DeserializeObject<List<int>>(sessionValue);
				if (listFilm.Contains(filmId))
				{
					listFilm.Remove(filmId);
				}
				listFilm.Insert(0, filmId);
			}

			var jsonSes = JsonConvert.SerializeObject(listFilm);
			Session.SetString(key, jsonSes);
		}

	}
}
