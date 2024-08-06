using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Areas.Admin.ViewModels.User;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.WebConfig.Consts;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using X.PagedList;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class UserController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;
		private readonly string DefaultImagePath = "upload/img_avt/avt_default.png";// Đường dẫn đến ảnh mặc định

		public UserController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize(AuthConst.AppUser.VIEW_LIST)]
		public async Task<IActionResult> Index(int page = 1, int size = PAGE_SIZE)
		{
			var data = (await _db.AppUser
								.Where(m => m.DeletedDate == null &&  !m.Username.Contains(CurrentUsername) && m.AppRoleId != AppConst.ROLE_ADMINISTRATOR_ID)
								.Select(m => new UserListItemVM
								{
									Id = m.Id,
									Username = m.Username,
									FullName = m.FullName,
									Email = m.Email,
									PhoneNumber1 = m.PhoneNumber1,
									BlockedTo = m.BlockedTo,
									CreatedDate = m.CreatedDate,
									RoleName = m.AppRole.Name
								})
								.ToPagedListAsync(page, size))
								.GenRowIndex();
			return View(data);
		}

		[AppAuthorize(AuthConst.AppUser.CREATE)]
		public IActionResult Create() => View();

		[HttpPost]
		[AppAuthorize(AuthConst.AppUser.CREATE)]
		public async Task<IActionResult> Create(UserAddOrEditVM model)
		{
			model.Username = model.Username.ToLower();
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}

			if (await _db.AppUser.AnyAsync(u => u.Username == model.Username))
			{
				SetErrorMesg("Username already exists, please check again!");
				return View(model);
			}

			try
			{
				var hashResult = HashHMACSHA512(model.Password);
				model.PasswordHash = hashResult.Value;
				model.PasswordSalt = hashResult.Key;
				
				AppUser user = new();
				user.Username = model.Username;
				user.FullName = model.FullName;
				user.Email = model.Email;
				user.PhoneNumber1 = model.PhoneNumber1;
				user.PhoneNumber2 = model.PhoneNumber2;
				user.CreatedDate = DateTime.Now;
				user.CreatedBy = CurrentUserId;
				user.Address = model.Address;
				user.Avatar = DefaultImagePath.TrimStart('/');
				user.PasswordHash = model.PasswordHash;
				user.PasswordSalt = model.PasswordSalt;
				user.AppRoleId = model.AppRoleId;

				await _db.AppUser.AddAsync(user);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Added account ⌈ {user.Username} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(model);
			}
		}


		[AppAuthorize(AuthConst.AppUser.UPDATE)]
		public async Task<IActionResult> Edit(int id)
		{
			var user = await _db.FindAsync<AppUser>(id);
			if (user == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			var userEditVM = new UserAddOrEditVM
			{
				Id = id,
				Username = user.Username,
				FullName = user.FullName,
				Email = user.Email,
				PhoneNumber1 = user.PhoneNumber1,
				PhoneNumber2 = user.PhoneNumber2,
				AppRoleId = user.AppRoleId,
				Address = user.Address
			};
			return View(userEditVM);
		}

		[HttpPost]
		[AppAuthorize(AuthConst.AppUser.UPDATE)]
		public async Task<IActionResult> Edit(UserAddOrEditVM model)
		{
			var user = await _db.FindAsync<AppUser>(model.Id);

			// Không validate các trường dưới dây khi cập nhật
			ModelState.Remove("Username");
			ModelState.Remove("Password");
			ModelState.Remove("ConfirmPwd");

			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return View(model);
			}
			if (user == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			
			try
			{
				user.Address = model.Address;
				user.AppRoleId = model.AppRoleId;
				user.Email = model.Email;
				user.FullName = model.FullName;
				user.PhoneNumber1 = model.PhoneNumber1;
				user.PhoneNumber2 = model.PhoneNumber2;
				user.UpdatedDate = DateTime.Now;
				user.UpdatedBy = CurrentUserId;

				_db.Update(user);
				await _db.SaveChangesAsync();
				SetSuccessMesg($"Updated account ⌈ {user.Username} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View(model);
			}
		}

		[AppAuthorize(AuthConst.AppUser.BLOCK)]
		public async Task<IActionResult> _BlockUser(int id)
		{
			var data = await _db.FindAsync<AppUser>(id);
			return PartialView(data);
		}
		[HttpPost]
		[AppAuthorize(AuthConst.AppUser.BLOCK)]
		public async Task<IActionResult> _BlockUser(BlockUserVM data)
		{
			try
			{
				var user = await _db.FindAsync<AppUser>(data.Id);
				user.BlockedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
				if (data.Permanentblock)
				{
					var date = DateTime.Now;
					var blockTime = date.AddYears(100);
					user.BlockedTo = blockTime;
				}
				else
				{
					user.BlockedTo = data.BlockedTo;
				}
				SetSuccessMesg($"Locked account ⌈ {user.Username} ⌋ successfully");
				_db.Update(user);
				await _db.SaveChangesAsync();
				return Ok(true);
			}
			catch
			{
				return Ok(false);
			}

		}
		[AppAuthorize(AuthConst.AppUser.UNBLOCK)]
		public async Task<IActionResult> UnBlockUser(int id)
		{
			var user = await _db.FindAsync<AppUser>(id);
			user.BlockedTo = null;
			user.BlockedBy = null;
			_db.Update(user);
			await _db.SaveChangesAsync();
			SetSuccessMesg($"Unlocked account ⌈ {user.Username} ⌋ successfully");
			return RedirectToAction(nameof(Index));
		}
	}
}
