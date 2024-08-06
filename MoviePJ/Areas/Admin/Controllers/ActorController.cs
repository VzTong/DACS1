using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Areas.Admin.ViewModels.FilmActor;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using X.PagedList;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class ActorController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;
		private readonly string DefaultImagePath = "images/img_err.png";// Đường dẫn đến ảnh mặc định

		public ActorController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize(AuthConst.AppActor.VIEW_LIST)]
		public async Task<IActionResult> Index(int page = 1, int size = PAGE_SIZE)
		{
			var data = (await _db.AppActors
								.Where(m => m.DeletedDate == null)
								.OrderByDescending(m => m.Id)
								.Select(m => new ListItemActorsVM
								{
									Id = m.Id,
									FullName = m.FullName,
									Avatar = m.Avatar
								})
								.ToPagedListAsync(page, size))
								.GenRowIndex();
			return View(data);
		}

		[AppAuthorize(AuthConst.AppActor.CREATE)]
		[HttpPost]
		public async Task<IActionResult> AddActor(AddOrUpdateActorVM Actor, [FromServices] IWebHostEnvironment env)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			// Chuẩn hóa Name
			Actor.FullName = Actor.FullName.ToLower().Trim();

			// Check Name đã tồn tại chưa
			var exists = await _db.AppActors.AnyAsync(g => g.FullName == Actor.FullName);

			if (exists)
			{
				SetErrorMesg("This actor already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{
				// Copy dữ liệu từ view model sang nodel
				var act = new AppActor
				{
					FullName = Actor.FullName,
					CreatedBy = CurrentUserId,
					CreatedDate = DateTime.Now,
				};

				act.Avatar = UploadFile(Actor.AvatarUpload, env.WebRootPath);


				await _db.AddAsync(act);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Add actor ⌈ {act.FullName} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return RedirectToAction(nameof(Index));
			}
		}

		[AppAuthorize(AuthConst.AppActor.UPDATE)]
		[HttpPost]
		public async Task<IActionResult> UpdateActor(AddOrUpdateActorVM Actor, [FromServices] IWebHostEnvironment env)
		{
			var act = await _db.AppActors
									.Include(s => s.AppFilmActors)
									.FirstOrDefaultAsync(i => i.Id == Actor.Id);

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index));
			}

			if (act == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index));
			}

			// Check Name đã tồn tại chưa
			var exists = await _db.AppActors.AnyAsync(u => u.FullName.Equals(Actor.FullName) && u.FullName != Actor.FullName);


			if (exists)
			{
				SetErrorMesg("This actor already exists!");
				return RedirectToAction(nameof(Index));
			}
			try
			{

				act.FullName = Actor.FullName;

				if (Actor.AvatarUpload != null)
				{
					var img = Path.Combine(env.WebRootPath, act.Avatar.TrimStart('/'));
					if (System.IO.File.Exists(img))
					{
						System.IO.File.Delete(img);
					}

					act.Avatar = UploadFile(Actor.AvatarUpload, env.WebRootPath);
				}

				act.UpdatedDate = DateTime.Now;
				act.UpdatedBy = CurrentUserId;

				_db.Update(act);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Update actor ⌈ {act.FullName} ⌋ successfully");
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
			var actor = await _db.FindAsync<AppActor>(id);
			int actorIdToCheck = actor.Id;
			var filmsOfActor = await _db.AppFilms
											.Where(film => film.AppFilmActors.Any(fm => fm.AppActorId == actorIdToCheck)
													&& film.AppFilmActors.Any(f => f.AppFilmId == film.Id)).ToListAsync();

			if (actor == null)
			{
				SetErrorMesg("This actor does not exist or has been previously removed!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (filmsOfActor.Count > 0)
			{
				SetErrorMesg("The actor contains films so it cannot be deleted!");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var now = DateTime.Now;

			actor.DeletedDate = now;
			actor.UpdatedBy = CurrentUserId;

			_db.Update(actor);
			await _db.SaveChangesAsync();

			SetSuccessMesg($"Actor ⌈ {actor.FullName} ⌋ has been successfully deleted");
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
			var res = "upload/Actor_img/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/Actor_img", fName);

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
