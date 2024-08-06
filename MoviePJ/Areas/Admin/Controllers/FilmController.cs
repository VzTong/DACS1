using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviePJ.Areas.Admin.ViewModels.Film;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.Extensions;
using NuGet.Protocol.Core.Types;
using System.Drawing;
using System.Linq;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class FilmController : AppControllerBase
	{
		private readonly string DefaultImagePath = "images/img_err.png";// Đường dẫn đến ảnh mặc định
		private readonly string DefaultVideoPath = "images/Video_errol.mp4";// Đường dẫn đến ảnh mặc định
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;

		public FilmController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		public async Task<IActionResult> Index(SearchFilmVM search, int page = 1, int size = PAGE_SIZE)
		{
			var data = await GetListfilmAsync(search, page, size);

			var listgenre = await _db.AppGenres
									.Where(x => x.DeletedDate == null)
									.Include(x => x.ParentCategory)
									.ToListAsync();

			var releaseYears = await _db.AppFilms
											.Where(f => f.DeletedDate == null)
											.Select(f => new { f.ReleaseYear })
											.Distinct()
											.ToListAsync();

			var Liststatus = await _db.AppStatus
											.Where(f => f.DeletedDate == null)
											.Distinct()
											.ToListAsync();

			ViewBag.Genre = new SelectList(listgenre, "Id", "Name", search.CateId, "CateLevel");
			ViewBag.IsYears = new SelectList(releaseYears, "ReleaseYear", "ReleaseYear", search.ReleaseYear);
			ViewBag.IsStatus = new SelectList(Liststatus, "Id", "Name", search.StatusID);

			ViewBag.FilmName = search.FilmName;
			ViewBag.CateId = search.CateId;
			ViewBag.ReleaseYear = search.ReleaseYear;
			ViewBag.Status = search.StatusID;
			return View(data);
		}
		private async Task<IPagedList<ListItemFilmVM>> GetListfilmAsync(SearchFilmVM search, int page, int size)
		{
			var query = _db.AppFilms
							.Include(x => x.AppGenresFilms)
							.AsNoTracking()
							.Where(f => f.DeletedDate == null);

			if (!search.FilmName.IsNullOrEmpty())
			{
				query = query.Where(x => x.Name.Contains(search.FilmName) || x.Slug.Contains(search.FilmName.Slugify()));
			}
			if (search.CateId != null)
			{
				if (search.CateId == -1) // Không có danh mục
				{
					query = query.Where(x => x.AppGenresFilms.Any(gf => gf.GenresId == null));
				}
				else
				{
					query = query.Where(x => x.AppGenresFilms.Any(gf => gf.GenresId == search.CateId));
				}
			}
			if (search.ReleaseYear != null)
			{
				query = query.Where(x => x.ReleaseYear == search.ReleaseYear);
			}
			if (search.StatusID != null)
			{
				query = query.Where(x => x.StatusId == search.StatusID);
			}

			var data = (await query.OrderByDescending(m => m.DisplayOrder)
									.ThenByDescending(m => m.Id)
									.Select(m => new ListItemFilmVM
									{
										Id = m.Id,
										Name = m.Name,
										AnotherName = m.AnotherName,
										Slug = m.Slug,
										Cover = m.Cover,
										Desc = m.Desc,
										Country = m.Country,
										Language = m.Language,
										ReleaseYear = m.ReleaseYear,
										Time = m.Time,
										AppGenresFilms = m.AppGenresFilms,
										IsActive = m.IsActive,
										DisplayOrder = m.DisplayOrder,
										StatusName = m.AppStatus.Name,
										GenresName = _db.AppGenres
															.Where(g => g.AppGenresFilms.Any(gf => gf.GenresId == g.Id) && g.AppGenresFilms.Any(gf => gf.FilmId == m.Id))
															.Select(g => g.Name).Distinct().ToList()
									})
									.ToPagedListAsync(page, size))
								.GenRowIndex();
			return data;
		}

		[AppAuthorize(AuthConst.AppFilm.CREATE)]
		public IActionResult Create()
		{
			return View();
		}

		[AppAuthorize(AuthConst.AppFilm.CREATE)]
		[RequestSizeLimit(100_000_000)]
		[RequestFormLimits(MultipartBodyLengthLimit = 51200000000)]
		[HttpPost]
		public async Task<IActionResult> Create(AddOrUpdateFilmVM model, [FromServices] IWebHostEnvironment env)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			
			// Kiểm tra sự tồn tại của bộ phim
			var check = await _db.AppFilms.Where(x => x.Name.ToLower() == model.Name.ToLower()).FirstOrDefaultAsync();
			if (check != null)
			{
				SetErrorMesg("Film already exists!");
				return View(model);
			}

			// Thêm dữ liệu thể loại con cho bộ phim
			if (model.GenreId is not null)
			{
				foreach (var item in model.GenreId)
				{
					// Lấy thông tin thể loại
					var genre = await _db.AppGenres.Include(g => g.ParentCategory).FirstOrDefaultAsync(g => g.Id == item);
					if (genre != null)
					{
						// Thêm thể loại con
						model.AppGenresFilms.Add(new AppGenresFilm
						{
							GenresId = item,
							CreatedDate = DateTime.Now,
							CreatedBy = CurrentUserId
						});

						// Nếu thể loại có thể loại cha
						if (genre.ParentCategory != null)
						{
							// Thêm thể loại cha
							model.AppGenresFilms.Add(new AppGenresFilm
							{
								GenresId = genre.ParentCategory.Id,
								CreatedDate = DateTime.Now,
								CreatedBy = CurrentUserId
							});

						}
					}
				}
			}

			if (model.StudioId is not null)
			{
				//studio
				foreach (var item in model.StudioId)
				{
					model.AppStudioFilms.Add(new AppStudioFilm
					{
						StudioId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}
			}

			if (model.MakerId is not null)
			{
				//Makers
				foreach (var item in model.MakerId)
				{
					model.AppFilmmakers.Add(new AppFilmmaker
					{
						MakerId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}
			}

			if (model.ActorId is not null)
			{
				//Actors
				foreach (var item in model.ActorId)
				{
					model.AppFilmActors.Add(new AppFilmActor
					{
						AppActorId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}
			}

			var eps = new IFormFile[] { model.PathEp1_Upload , model.PathEp2_Upload , model.PathEp3_Upload,
										model.PathEp4_Upload , model.PathEp5_Upload , model.PathEp6_Upload,
										model.PathEp7_Upload , model.PathEp8_Upload , model.PathEp9_Upload,
										model.PathEp10_Upload , model.PathEp11_Upload , model.PathEp12_Upload,
										model.PathEp13_Upload , model.PathEp14_Upload , model.PathEp15_Upload,
										model.PathEp16_Upload , model.PathEp17_Upload , model.PathEp18_Upload,
										model.PathEp19_Upload , model.PathEp20_Upload , model.PathEp21_Upload,
										model.PathEp22_Upload , model.PathEp23_Upload , model.PathEp24_Upload
			};

			//Episode
			for (var i = 0; i < eps.Length; i++)
			{
				var path = "";

				if (eps[i] is not null)
				{
					path = UploadEpisode(eps[i], env.WebRootPath);
				}
				model.AppEpisodes.Add(new AppEpisode
				{
					EpNumber = i + 1,
					Path = path,
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now

				});
			}

			try
			{
				// Copy dữ liệu từ view model sang nodel
				var film = new AppFilm
				{
					Name = model.Name,
					AnotherName = model.AnotherName,
					Desc = model.Desc,
					ReleaseYear = model.ReleaseYear,
					Time = model.Time,
					EpisodeCount = model.EpisodeCount,
					TrailerPath = model.TrailerPath,
					Country = model.Country,
					Language = model.Language,
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now,
					AppFilmActors = model.AppFilmActors,
					AppGenresFilms = model.AppGenresFilms,
					AppStudioFilms = model.AppStudioFilms,
					AppFilmmakers = model.AppFilmmakers,
					StatusId = model.StatusId,
					AppEpisodes = model.AppEpisodes,
				};

				film.Cover = UploadFile(model.CoverUpload, env.WebRootPath);
				film.TrailerPath = UploadFileTrailer(model.TrailerPathFile, env.WebRootPath);

				film.Slug = film.Name.Slugify();
				film.IsActive = true;


				await _db.AddAsync(film);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Add film ⌈ {film.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(model);
			}
		}

		[AppAuthorize(AuthConst.AppFilm.UPDATE)]
		public async Task<IActionResult> Update(int id)
		{
			var query = await _db.AppFilms.FindAsync(id);

			var data = new AddOrUpdateFilmVM();
			data.Name = query.Name ?? "";
			data.Cover = query.Cover;
			data.Slug = query.Slug;
			data.AnotherName = query.AnotherName;
			data.ReleaseYear = query.ReleaseYear;
			data.Time = query.Time;
			data.EpisodeCount = query.EpisodeCount;
			data.Desc = query.Desc;
			data.TrailerPath = query.TrailerPath;
			data.Cover = query.Cover;
			data.Country = query.Country;
			data.Language = query.Language;
			data.StatusId = query.StatusId;
			data.AppEpisodes = query.AppEpisodes;
			data.ActorId = _db.AppFilmActors.Where(x => x.AppFilmId == id && x.AppActorId.HasValue)
							.Select(x => x.AppActorId.Value)
							.Distinct()
							.ToList();
			data.GenreId = _db.AppGenresFilms.Where(x => x.FilmId == id)
							.Select(x => x.GenresId.Value)
							.Distinct()
							.ToList();
			data.StudioId = _db.AppStudioFilm.Where(x => x.FilmId == id)
							.Select(x => x.StudioId)
							.Distinct()
							.ToList();
			data.MakerId = _db.AppFilmmaker.Where(x => x.FilmId == id && x.MakerId.HasValue)
							.Select(x => x.MakerId.Value)
							.Distinct()
							.ToList();
			data.Id = id;

			data.AppEpisodes = _db.AppEpisodes
							.Where(x => x.FilmId == id)
							.Select(x => new AppEpisode
							{
								Id = x.Id,
								EpNumber = x.EpNumber,
								Path = x.Path,
							})
							.Distinct()
							.ToList();

			return View(data);
		}
		[HttpPost]
		public async Task<IActionResult> Update(AddOrUpdateFilmVM model, [FromServices] IWebHostEnvironment env)
		{
			var film = await _db.AppFilms.FindAsync(model.Id);
			if (!ModelState.IsValid)
			{
				//SetErrorMesg(MODEL_STATE_INVALID_MESG); loi ne fix di
				return View(model);
			}
			if (film is null)
			{
				SetErrorMesg("Film already exist!");
				return View(model);
			}

			if (model.GenreId is not null)
			{
				// Lấy danh sách các bản ghi hiện có liên quan đến bộ phim (FilmId)
				var existingGenres = _db.AppGenresFilms
					.Where(agf => agf.FilmId == model.Id)
					.ToList();

				// Xóa các bản ghi hiện có
				_db.AppGenresFilms.RemoveRange(existingGenres);
				await _db.SaveChangesAsync();

				//Genres
				foreach (var item in model.GenreId)
				{
					// Lấy thông tin thể loại
					var genre = await _db.AppGenres.Include(g => g.ParentCategory).FirstOrDefaultAsync(g => g.Id == item);
					if (genre != null)
					{
						// Thêm thể loại con
						model.AppGenresFilms.Add(new AppGenresFilm
						{
							GenresId = item,
							CreatedDate = DateTime.Now,
							CreatedBy = CurrentUserId
						});

						// Nếu thể loại có thể loại cha
						if (genre.ParentCategory != null)
						{
							// Thêm thể loại cha
							model.AppGenresFilms.Add(new AppGenresFilm
							{
								GenresId = genre.ParentCategory.Id,
								CreatedDate = DateTime.Now,
								CreatedBy = CurrentUserId
							});

						}
					}
				}
			}

			if (model.StudioId is not null)
			{
				// Lấy danh sách các bản ghi hiện có liên quan đến bộ phim (FilmId)
				var existingStudio = _db.AppStudioFilm
					.Where(agf => agf.FilmId == model.Id)
					.ToList();

				// Xóa các bản ghi hiện có
				_db.AppStudioFilm.RemoveRange(existingStudio);
				await _db.SaveChangesAsync();
				//studio
				foreach (var item in model.StudioId)
				{
					model.AppStudioFilms.Add(new AppStudioFilm
					{
						StudioId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}
			}

			if (model.MakerId is not null)
			{
				// Lấy danh sách các bản ghi hiện có liên quan đến bộ phim (FilmId)
				var existingMaker = _db.AppFilmmaker
					.Where(agf => agf.FilmId == model.Id)
					.ToList();

				// Xóa các bản ghi hiện có
				_db.AppFilmmaker.RemoveRange(existingMaker);
				//Makers
				foreach (var item in model.MakerId)
				{
					model.AppFilmmakers.Add(new AppFilmmaker
					{
						MakerId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}
			}

			if (model.ActorId is not null)
			{
				// Lấy danh sách các bản ghi hiện có liên quan đến bộ phim (FilmId)
				var existingActor = _db.AppFilmActors
					.Where(agf => agf.AppFilmId == model.Id)
					.ToList();

				// Xóa các bản ghi hiện có
				_db.AppFilmActors.RemoveRange(existingActor);
				//Actors
				foreach (var item in model.ActorId)
				{
					model.AppFilmActors.Add(new AppFilmActor
					{
						AppActorId = item,
						CreatedDate = DateTime.Now,
						CreatedBy = CurrentUserId
					});
				}

			}

			// Cập nhật tập film
			var episodePaths = await _db.AppEpisodes
											.Where(ep => ep.FilmId == film.Id)
											.OrderBy(ep => ep.EpNumber)
											.ToListAsync();

			// Tạo một danh sách chứa tất cả các tập phim từ model
			var episodes = new List<(IFormFile file, int episodeNumber)>
			{
				(model.PathEp1_Upload, 1), (model.PathEp2_Upload, 2), (model.PathEp3_Upload, 3),
				(model.PathEp4_Upload, 4), (model.PathEp5_Upload, 5), (model.PathEp6_Upload, 6),
				(model.PathEp7_Upload, 7), (model.PathEp8_Upload, 8), (model.PathEp9_Upload, 9),
				(model.PathEp10_Upload,	10) ,(model.PathEp11_Upload, 11), (model.PathEp12_Upload, 12),
				(model.PathEp13_Upload,	13) ,(model.PathEp14_Upload, 14), (model.PathEp15_Upload, 15),
				(model.PathEp16_Upload,	16) ,(model.PathEp17_Upload, 17), (model.PathEp18_Upload, 18),
				(model.PathEp19_Upload,	19) ,(model.PathEp20_Upload, 20), (model.PathEp21_Upload, 21),
				(model.PathEp22_Upload,	22) ,(model.PathEp23_Upload, 23), (model.PathEp24_Upload, 24)
				// Thêm các tập phim còn lại ở đây...
			};

			foreach (var episodeInfo in episodes)
			{
				var episodeFile = episodeInfo.file;
				var episodeNumber = episodeInfo.episodeNumber;
				string path = null; // Declare path variable outside of the if block

				if (episodeFile is not null)
				{
					path = UploadEpisode(episodeFile, env.WebRootPath);
				}

				// Kiểm tra xem chỉ số tập phim đã tồn tại trong danh sách episodePaths không
				var existingEpisode = episodePaths.FirstOrDefault(ep => ep.EpNumber == episodeNumber);

				if (existingEpisode != null)
				{
					// Nếu tập phim đã tồn tại, kiểm tra xem đường dẫn có thay đổi không
					if (path != null && existingEpisode.Path != path)
					{
						// Nếu có thay đổi, cập nhật thông tin cho tập phim
						existingEpisode.Path = path;
						existingEpisode.UpdatedBy = CurrentUserId;
						existingEpisode.UpdatedDate = DateTime.Now;
						_db.Update(existingEpisode);
					}
					// Nếu không có thay đổi, bỏ qua việc cập nhật
				}
				else
				{
					// Nếu tập phim chưa tồn tại, tạo mới và thêm vào danh sách
					var newEpisode = new AppEpisode
					{
						FilmId = film.Id, // Set the FilmId to the ID of the film
						EpNumber = episodeNumber, // Chỉ số bắt đầu từ 1
						Path = path ?? "", // Use null-coalescing operator to handle null path
						CreatedBy = CurrentUserId,
						CreatedDate = DateTime.Now
					};

					_db.AppEpisodes.Add(newEpisode);
				}
			}

			try
			{
				film.Name = model.Name;
				film.AnotherName = model.AnotherName;
				film.Desc = model.Desc;
				film.ReleaseYear = model.ReleaseYear;
				film.Time = model.Time;
				film.EpisodeCount = model.EpisodeCount;
				film.Country = model.Country;
				film.Language = model.Language;
				film.UpdatedBy = CurrentUserId;
				film.UpdatedDate = DateTime.Now;
				film.AppFilmActors = model.AppFilmActors;
				film.AppGenresFilms = model.AppGenresFilms;
				film.AppStudioFilms = model.AppStudioFilms;
				film.AppFilmmakers = model.AppFilmmakers;
				film.StatusId = model.StatusId;

				if (model.CoverUpload != null)
				{
					var img = Path.Combine(env.WebRootPath, film.Cover.TrimStart('/'));
					if (System.IO.File.Exists(img))
					{
						System.IO.File.Delete(img);
					}

					film.Cover = UploadFile(model.CoverUpload, env.WebRootPath);
				}

				if (model.TrailerPathFile != null)
				{
					var path = Path.Combine(env.WebRootPath, film.TrailerPath.TrimStart('/'));
					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(path);
					}

					film.TrailerPath = UploadFileTrailer(model.TrailerPathFile, env.WebRootPath);
				}

				film.Slug = film.Name.Slugify();
				film.IsActive = true;

				_db.Update(film);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Update film ⌈ {film.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(model);
			}

		}

		[AppAuthorize(AuthConst.AppFilm.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var film = await _db.FindAsync<AppFilm>(id);
			if (film == null)
			{
				SetErrorMesg("This film does not exist or has been previously deleted");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			// Gỡ khóa ngoại
			film.StatusId = null;
			film.AppGenresFilms = null;
			film.AppComments = null;
			film.AppEpisodes = null;
			film.AppFilmmakers = null;
			film.AppFilmActors = null;
			film.AppStudioFilms = null;


			var entity = await _db.AppFilms.FindAsync(film.Id);
			if (entity != null)
			{
				// Đánh dấu bản ghi là đã xóa
				entity.DeletedDate = DateTime.Now;
				entity.UpdatedBy = CurrentUserId; // Nếu có thông tin người cập nhật

				// Lưu thay đổi vào cơ sở dữ liệu
				await _db.SaveChangesAsync();
			}
			SetSuccessMesg($"Film ⌈ {film.Name} ⌋ was successfully deleted");
			if (Referer != null)
			{
				return Redirect(Referer);
			}
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		[AppAuthorize(AuthConst.AppFilm.DELETE)]
		public async Task<IActionResult> BulkDelete(List<int> ids)
		{

			if (ids.Count > 0)
			{
				foreach (var i in ids)
				{
					int id = Convert.ToInt32(i);

					var entity = await _db.AppFilms.FindAsync(id);

					if (entity != null)
					{
						// Đánh dấu bản ghi là đã xóa
						entity.DeletedDate = DateTime.Now;
						entity.UpdatedBy = CurrentUserId; // Nếu có thông tin người cập nhật

						// Lưu thay đổi vào cơ sở dữ liệu
						await _db.SaveChangesAsync();
					}
				}
				SetSuccessMesg($"Removed ⌈ {ids.Count} ⌋ film!");
			}
			else
			{
				SetErrorMesg("No films have been selected yet!");
			}
			if (!Referer.IsNullOrEmpty())
			{
				return Redirect(Referer);
			}
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		[AppAuthorize(AuthConst.AppFilm.PUBLIC)]
		public async Task<IActionResult> Publicfilm(int id)
		{
			var film = await _db.FindAsync<AppFilm>(id);
			if (film == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			film.IsActive = true;
			_db.Update(film);
			await _db.SaveChangesAsync();
			SetSuccessMesg($"Publicizing the film ⌈ {film.Name} ⌋ was successful");
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		[AppAuthorize(AuthConst.AppFilm.UNPUBLIC)]
		public async Task<IActionResult> UnPublicfilm(int id)
		{
			var film = await _db.FindAsync<AppFilm>(id);
			if (film == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			film.IsActive = false;
			_db.Update(film);
			await _db.SaveChangesAsync();
			SetSuccessMesg($"Unpublicized the movie ⌈ {film.Name} ⌋ was successful");
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		public async Task<IActionResult> filmPin(int id = 0)
		{
			if (id > 0)
			{
				var film = await _db.FindAsync<AppFilm>(id);
				var maxDisplayOrder = _db.AppFilms.Max(x => x.DisplayOrder);
				film.DisplayOrder = maxDisplayOrder != null ? maxDisplayOrder + 1 : 1;
				_db.Update(film);
				await _db.SaveChangesAsync();
			}
			return Redirect(Referer);
		}
		public async Task<IActionResult> filmUnPin(int id = 0)
		{
			if (id > 0)
			{
				var film = await _db.FindAsync<AppFilm>(id);
				film.DisplayOrder = null;
				_db.Update(film);
				await _db.SaveChangesAsync();
			}
			return Redirect(Referer);
		}

		/// <summary>
		/// Upload và trả về tên file, file đó được lưu trong thư mục Upload
		/// </summary>
		/// <param name="file">Là file đó</param>
		/// <param name="dir">Thư mục lưu file</param>
		/// <returns></returns>
		// Viết hàm xử lý ảnh riêng
		private string UploadFile(IFormFile file, string dir)
		{
			if (file == null)
			{
				// Người dùng không upload ảnh, sử dụng ảnh mặc định
				var defaultImageBytes = System.IO.File.ReadAllBytes(DefaultImagePath.TrimStart('/'));
				return Convert.ToBase64String(defaultImageBytes);
			}

			// upload ảnh bìa (CoverImg)
			var fName = file.FileName;
			fName = Path.GetFileNameWithoutExtension(fName)
					+ DateTime.Now.Ticks
					+ Path.GetExtension(fName);

			// Gán giá trị cột CoverImg
			var res = "upload/Film_img/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Film_img", fName);

			// Tạo Stream để lưu file
			var stream = System.IO.File.Create(fName);
			file.CopyTo(stream);
			stream.Dispose(); // Giải phóng bộ nhớ

			return res;
		}

		/// <summary>
		/// Upload và trả về tên file, file đó được lưu trong thư mục Upload
		/// </summary>
		/// <param name="file">Là file đó</param>
		/// <param name="dir">Thư mục lưu file</param>
		/// <returns></returns>

		// Viết hàm xử lý Trailer riêng
		private string UploadFileTrailer(IFormFile file, string dir)
		{
			// upload Trailer
			var fName = file.FileName;
			fName = Path.GetFileNameWithoutExtension(fName)
					+ DateTime.Now.Ticks
					+ Path.GetExtension(fName);

			// Gán giá trị cột TrailerPath
			var res = "upload/Trailer_Path/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Trailer_Path", fName);

			// Tạo Stream để lưu file
			var stream = System.IO.File.Create(fName);
			file.CopyTo(stream);
			stream.Dispose(); // Giải phóng bộ nhớ

			return res;
		}

		/// <summary>
		/// Upload và trả về tên file, file đó được lưu trong thư mục Upload
		/// </summary>
		/// <param name="file">Là file đó</param>
		/// <param name="dir">Thư mục lưu file</param>
		/// <returns></returns>

		// Viết hàm xử lý Episode riêng
		private string UploadEpisode(IFormFile file, string dir)
		{
			// upload Episode
			var fName = file.FileName;
			fName = Path.GetFileNameWithoutExtension(fName)
					+ DateTime.Now.Ticks
					+ Path.GetExtension(fName);

			// Gán giá trị cột Episode_Path
			var res = "upload/Episode_Path/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Episode_Path", fName);

			// Tạo Stream để lưu file
			var stream = System.IO.File.Create(fName);
			file.CopyTo(stream);
			stream.Dispose(); // Giải phóng bộ nhớ

			return res;
		}

	}
}