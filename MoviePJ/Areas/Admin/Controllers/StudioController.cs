using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Areas.Admin.ViewModels.FilmStudio;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using System.Drawing.Printing;
using X.PagedList;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class StudioController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;
		private readonly string DefaultImagePath = "images/img_err.png";// Đường dẫn đến ảnh mặc định

		public StudioController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize(AuthConst.AppStudio.VIEW_LIST)]
		public async Task<IActionResult> Index(int page = 1, int size = PAGE_SIZE)
		{
			var data = (await _db.AppStudio
								.Where(m => m.DeletedDate == null)
								.Select(m => new ListItemStudioVM
								{
									Id = m.Id,
									Name = m.Name,
									Cover = m.Cover
								})
								.OrderByDescending(m => m.Id)
								.ToPagedListAsync(page, size))
								.GenRowIndex();
			return View(data);
		}

		[AppAuthorize(AuthConst.AppStudio.CREATE)]
		[HttpPost]
		public async Task<IActionResult> AddStudio(AddOrUpdateStudioVM Studio, [FromServices] IWebHostEnvironment env)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			// Chuẩn hóa Name
			Studio.Name = Studio.Name.ToLower().Trim();

			// Check Name đã tồn tại chưa
			var exists = await _db.AppStudio.AnyAsync(g => g.Name == Studio.Name);

			if (exists)
			{
				SetErrorMesg("This studio already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{
				// Copy dữ liệu từ view model sang nodel
				var sto = new AppStudio
				{
					Name = Studio.Name,
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now,
				};

				sto.Cover = UploadFile(Studio.CoverUpload, env.WebRootPath);


				await _db.AddAsync(sto);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Add studio ⌈ {sto.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return RedirectToAction(nameof(Index));
			}
		}

		[AppAuthorize(AuthConst.AppStudio.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> UpdateStudio(AddOrUpdateStudioVM Studio, [FromServices] IWebHostEnvironment env)
		{
			var sto = await _db.AppStudio
									.Include(s => s.AppStudioFilms)
									.FirstOrDefaultAsync(i => i.Id == Studio.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			if (sto == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}

			// Check Name đã tồn tại chưa
			var exists = await _db.AppStudio.AnyAsync(u => u.Name.Equals(Studio.Name) && u.Name != Studio.Name);


			if (exists)
			{
				SetErrorMesg("This studio already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{

				sto.Name = Studio.Name;

				if (Studio.CoverUpload != null)
				{
					var img = Path.Combine(env.WebRootPath, sto.Cover.TrimStart('/'));
					if (System.IO.File.Exists(img))
					{
						System.IO.File.Delete(img);
					}

					sto.Cover = UploadFile(Studio.CoverUpload, env.WebRootPath);
				}

				sto.UpdatedDate = DateTime.Now;
				sto.UpdatedBy = CurrentUserId;

				_db.Update(sto);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Update studio ⌈ {sto.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return RedirectToAction(nameof(Index));
			}
		}

		[AppAuthorize(AuthConst.AppMaker.DELETE)]
		public async Task<IActionResult> Delete(int id)
		{
			var studio = await _db.FindAsync<AppStudio>(id);
			int studioIdToCheck = studio.Id;
			var filmsOfStudio = await _db.AppFilms
											.Where(film => film.AppStudioFilms.Any(fm => fm.StudioId == studioIdToCheck)
													&& film.AppStudioFilms.Any(f => f.FilmId == film.Id)).ToListAsync();

			if (studio == null)
			{
				SetErrorMesg("This studio does not exist or has been previously removed!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (filmsOfStudio.Count > 0)
			{
				SetErrorMesg("The studio contains films so it cannot be deleted!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var now = DateTime.Now;

			studio.DeletedDate = now;
			studio.UpdatedBy = CurrentUserId;

			_db.Update(studio);
			await _db.SaveChangesAsync();

			SetSuccessMesg($"Studio ⌈ {studio.Name} ⌋ has been successfully deleted");
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
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
			var res = "upload/Studio_img/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Studio_img", fName);

			// Tạo Stream để lưu file
			var stream = System.IO.File.Create(fName);
			file.CopyTo(stream);
			stream.Dispose(); // Giải phóng bộ nhớ

			return res;
		}

		[AppAuthorize(AuthConst.AppMaker.UPDATE)]
		public async Task<IActionResult> UpdateDisplayOrder(int id1, int id2)
		{
			var chkResult = await _db.AppGenres
								.Where(x => x.CateLevel == 1 && (x.Id == id1 || x.Id == id2))
								.ToListAsync();

			if (chkResult.Count != 2)
			{
				return Ok(false);
			}
			var make1 = chkResult[0];
			var make2 = chkResult[1];

			var sql = "UPDATE " + DB.AppMaker.TABLE_NAME + " SET DisplayOrder = {0} WHERE Id = {1}";

			var sql1 = System.String.Format(sql, make2.DisplayOrder, make1.Id);
			var sql2 = System.String.Format(sql, make1.DisplayOrder, make2.Id);

			await _db.Database.ExecuteSqlRawAsync(sql1);
			await _db.Database.ExecuteSqlRawAsync(sql2);
			return Ok(true);
		}
	}
}
