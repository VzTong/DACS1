using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using X.PagedList;
using MoviePJ.Common;
using MoviePJ.Areas.Admin.ViewModels.Filmmaker;
using MoviePJ.Consts;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Extensions;
using MoviePJ.ViewModels.Film;
using Humanizer.Localisation;
using Microsoft.Extensions.Hosting;


namespace MoviePJ.Areas.Admin.Controllers
{
	public class MakerController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;
		private readonly string DefaultImagePath = "images/img_err.png";// Đường dẫn đến ảnh mặc định

		public MakerController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize(AuthConst.AppMaker.VIEW_LIST)]
		public async Task<IActionResult> Index(int page = 1, int size = PAGE_SIZE)
		{
			var data = (await _db.AppMaker
								.Where(m => m.DeletedDate == null)
								.Select(m => new ListItemMakersVM
								{
									Id = m.Id,
									FullName = m.FullName,
									Avatar = m.Avatar
								})
								.OrderByDescending(m => m.Id)
								.ToPagedListAsync(page, size))
								.GenRowIndex();
			return View(data);
		}

		[AppAuthorize(AuthConst.AppMaker.CREATE)]
		[HttpPost]
		public async Task<IActionResult> AddFilmmaker(AddOrUpdateFilmmakerVM filmmaker, [FromServices] IWebHostEnvironment env)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			// Chuẩn hóa Name
			filmmaker.FullName = filmmaker.FullName.ToLower().Trim();

			// Check Name đã tồn tại chưa
			var exists = await _db.AppMaker.AnyAsync(g => g.FullName == filmmaker.FullName);

			if (exists)
			{
				SetErrorMesg("This filmmaker already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{
				// Copy dữ liệu từ view model sang nodel
				var maker = new AppMaker
				{
					FullName = filmmaker.FullName,
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now,
				};

				maker.Avatar = UploadFile(filmmaker.AvatarUpload, env.WebRootPath);


				await _db.AddAsync(maker);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Add filmmaker ⌈ {maker.FullName} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return RedirectToAction(nameof(Index));
			}
		}

		[AppAuthorize(AuthConst.AppMaker.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> UpdateFilmmaker(AddOrUpdateFilmmakerVM filmmaker, [FromServices] IWebHostEnvironment env)
		{
			var maker = await _db.AppMaker
									.Include(s => s.AppFilmmakers)
									.FirstOrDefaultAsync(i => i.Id == filmmaker.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			if (maker == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}

			// Check Name đã tồn tại chưa
			var exists = await _db.AppMaker.AnyAsync(u => u.FullName.Equals(filmmaker.FullName) && u.FullName != filmmaker.FullName);


			if (exists)
			{
				SetErrorMesg("This filmmaker already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{

				maker.FullName = filmmaker.FullName;

				if (filmmaker.AvatarUpload != null)
				{
					var img = Path.Combine(env.WebRootPath, maker.Avatar.TrimStart('/'));
					if (System.IO.File.Exists(img))
					{
						System.IO.File.Delete(img);
					}

					maker.Avatar = UploadFile(filmmaker.AvatarUpload, env.WebRootPath);
				}

				maker.UpdatedDate = DateTime.Now;
				maker.UpdatedBy = CurrentUserId;
				_db.Update(maker);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Update filmmaker ⌈ {maker.FullName} ⌋ successfully");
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
			var maker = await _db.FindAsync<AppMaker>(id);
			int makerIdToCheck = maker.Id;
			var filmsOfMaker = await _db.AppFilms
											.Where(film => film.AppFilmmakers.Any(fm => fm.MakerId == makerIdToCheck)
													&& film.AppFilmmakers.Any(f => f.FilmId == film.Id)).ToListAsync();

			if (maker == null)
			{
				SetErrorMesg("This maker does not exist or has been previously removed!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (filmsOfMaker.Count > 0)
			{
				SetErrorMesg("The maker contains films so it cannot be deleted!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var now = DateTime.Now;

			maker.DeletedDate = now;
			maker.UpdatedBy = CurrentUserId;

			_db.Update(maker);
			await _db.SaveChangesAsync();

			SetSuccessMesg($"Maker ⌈ {maker.FullName} ⌋ has been successfully deleted");
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
			var res = "upload/Filmmaker_img/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Filmmaker_img", fName);

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
