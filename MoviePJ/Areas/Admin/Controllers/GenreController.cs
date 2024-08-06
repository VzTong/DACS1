using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Areas.Admin.ViewModels.FilmGenres;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.Entities.Base;
using MoviePJ.Extensions;
using NuGet.Protocol.Core.Types;
using System.Linq;
using System.Security.Claims;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class GenreController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;

		public GenreController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize()]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[AppAuthorize(AuthConst.AppGenres.CREATE)]
		[HttpPost]
		public async Task<IActionResult> Index(AddOrUpdateFilmGenreVM productCate)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(productCate);
			}

			// Chuẩn hóa Name
			productCate.Name = productCate.Name.ToLower().Trim();

			// Check Name đã tồn tại chưa
			var exists = await _db.AppGenres.AnyAsync(g => g.Name.ToLower().Trim() == productCate.Name);

			if (exists)
			{
				SetErrorMesg("This category already exists!");
				return View(productCate);
			}
			try
			{
				// Copy dữ liệu từ view model sang nodel
				var genres = new AppGenres
				{
					Name = productCate.Name,
					Desc = productCate.Desc,
					ParentCateId = productCate.ParentCateId,
					Slug = productCate.Name.Slugify(),
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now,
				};

				if (productCate.ParentCateId == -1)
				{
					// Tính displayOrder
					var newDisplayOrder = _db.AppGenres
											.Where(x => x.CateLevel == 1 && x.DisplayOrder != null)
											.Min(x => x.DisplayOrder) ?? 0;
					genres.DisplayOrder = newDisplayOrder - 1;
					genres.ParentCateId = null;
					genres.HasChild = false;
					genres.CateLevel = 1;
				}
				else
				{
					var parent = await _db.AppGenres.FindAsync((int)productCate.ParentCateId);
					genres.CateLevel = parent.CateLevel + 1;
					parent.HasChild = true;

					_db.Update(parent);
					await _db.SaveChangesAsync();
				}

				await _db.AddAsync(genres);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Add category ⌈ {genres.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(productCate);
			}
		}

		[AppAuthorize(AuthConst.AppGenres.UPDATE)]
		public async Task<IActionResult> Edit(int id)
		{
			var productCate = await _db.FindAsync<AppGenres>(id);
			if (productCate == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var postVM = new AddOrUpdateFilmGenreVM
			{
				Id = id,
				Name = productCate.Name,
				Desc = productCate.Desc,
				ParentCateId = productCate.ParentCateId,
				Slug = productCate.Name.Slugify()
			};

			return View(postVM);
		}

		[AppAuthorize(AuthConst.AppGenres.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> Edit(AddOrUpdateFilmGenreVM model)
		{
			var genre = await _db.AppGenres.FirstOrDefaultAsync(i => i.Id == model.Id);

			if (genre.CateLevel.Equals(1))
			{
				model.ParentCateId = null;
			}
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (genre == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			// Check Name đã tồn tại chưa
			var exists = await _db.AppGenres.AnyAsync(u => u.Name.Equals(model.Name) && u.Name != genre.Name);

			if (exists)
			{
				SetErrorMesg("This category already exists!");
				return View(model);
			}
			try
			{

				if (genre.ParentCateId == -1)
				{
					// Tính displayOrder
					var newDisplayOrder = _db.AppGenres
											.Where(x => x.CateLevel == 1 && x.DisplayOrder != null)
											.Min(x => x.DisplayOrder) ?? 0;
					genre.DisplayOrder = newDisplayOrder - 1;
					genre.ParentCateId = null;
					genre.HasChild = false;
					genre.CateLevel = 1;
				}
				await _db.SaveChangesAsync();

				if (genre.ParentCateId != null)
				{
					var parentOld = await _db.AppGenres
										.Include(s => s.ChildCategories)
										.SingleOrDefaultAsync(s => s.Id == genre.ParentCateId);

					if (parentOld.ChildCategories.Count == 1)
					{
						parentOld.HasChild = false;

						_db.Update(parentOld);
						await _db.SaveChangesAsync();
					}
					var parent = await _db.AppGenres.FindAsync((int)model.ParentCateId);
					genre.CateLevel = parent.CateLevel + 1;
					parent.HasChild = true;

					_db.Update(parent);
					await _db.SaveChangesAsync();
				}

				genre.Name = model.Name;
				genre.Desc = model.Desc;
				genre.ParentCateId = model.ParentCateId;
				genre.UpdatedDate = DateTime.Now;
				genre.Slug = genre.Name.Slugify();

				await _db.SaveChangesAsync();

				SetSuccessMesg($"Updated category ⌈ {genre.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(model);
			}
		}

		[AppAuthorize(AuthConst.AppGenres.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var category = await _db.FindAsync<AppGenres>(id);
			int categoryIdToCheck = category.Id;
			var filmsInCategory = await _db.AppFilms
											.Where(film => film.AppGenresFilms.Any(genreFilm => genreFilm.GenresId == categoryIdToCheck)
													&& film.AppGenresFilms.Any(gf => gf.FilmId == film.Id)).ToListAsync();

			if (category == null)
			{
				SetErrorMesg("This genre does not exist or has been previously removed!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (category.HasChild)
			{
				SetErrorMesg("Genres contain subgenres so they cannot be deleted!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (category.CateLevel.Equals(2) && filmsInCategory.Count > 0)
			{
				SetErrorMesg("The genres contains films so it cannot be deleted!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (category.ParentCateId != null)
			{
				var parent = await _db.AppGenres
										.Include(s => s.ChildCategories)
										.SingleOrDefaultAsync(s => s.Id == category.ParentCateId);

				// Đếm số lượng ChildCategories
				int childCategoryCount = parent.ChildCategories.Count;

				if (parent.ChildCategories.Count == 1)
				{
					parent.HasChild = false;

					_db.Update(parent);
					await _db.SaveChangesAsync();
				}

				await _db.SaveChangesAsync();
			}

			var now = DateTime.Now;

			category.DeletedDate = now;
			if (_httpContext != null)
			{
				category.UpdatedBy = CurrentUserID();
			}

			_db.Update(category);
			await _db.SaveChangesAsync();

			SetSuccessMesg($"Genres ⌈ {category.Name} ⌋ has been successfully deleted");
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		[AppAuthorize(AuthConst.AppGenres.UPDATE)]
		public async Task<IActionResult> UpdateDisplayOrder(int id1, int id2)
		{
			var chkResult = await _db.AppGenres
								.Where(x => x.CateLevel == 1 && (x.Id == id1 || x.Id == id2))
								.ToListAsync();

			if (chkResult.Count != 2)
			{
				return Ok(false);
			}
			var cate1 = chkResult[0];
			var cate2 = chkResult[1];

			var sql = "UPDATE " + DB.AppGenres.TABLE_NAME + " SET DisplayOrder = {0} WHERE Id = {1}";

			var sql1 = System.String.Format(sql, cate2.DisplayOrder, cate1.Id);
			var sql2 = System.String.Format(sql, cate1.DisplayOrder, cate2.Id);

			await _db.Database.ExecuteSqlRawAsync(sql1);
			await _db.Database.ExecuteSqlRawAsync(sql2);
			return Ok(true);
		}
	}
}
