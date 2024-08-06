using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviePJ.Areas.Admin.ViewModels.Account;
using MoviePJ.Entities;
using MoviePJ.WebConfig.Consts;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class AccountController : AppControllerBase
	{
		private readonly string DefaultImagePath = "upload/img_avt/avt_default.png";// Đường dẫn đến ảnh mặc định
		public readonly INotyfService _notyf;
		public AccountController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		public IActionResult Login() => User.Identity.IsAuthenticated ? HomePage() : View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			if (!ModelState.IsValid)
			{
				TempData["Mesg"] = "You have not entered data yet";
				return View();
			}

			var username = await _db.AppUser.SingleOrDefaultAsync(u => u.Username.ToLower() == model.Username.ToLower());


			if (username is null)
			{
				TempData["Mesg"] = "Account does not exist";
				return View();
			}

			var user = _db.AppUser
						.Where(x => x.Username.ToLower() == model.Username.ToLower())
						.Select(u => new UserDataForApp
						{
							Id = u.Id,
							Username = u.Username,
							PasswordHash = u.PasswordHash,
							PasswordSalt = u.PasswordSalt,
							FullName = u.FullName,
							PhoneNumber1 = u.PhoneNumber1,
							PhoneNumber2 = u.PhoneNumber2,
							Email = u.Email,
							Avatar = u.Avatar,
							Address = u.Address,
							BlockedTo = u.BlockedTo,
							BlockedBy = u.BlockedBy,
							AppRoleId = u.AppRoleId,
							CreatedDate = u.CreatedDate,
							RoleName = u.AppRole.Name,
							Permission = string.Join(',', u.AppRole.AppRolePermissions.Select(p => p.MstPermissionId)),
						}).First();

            if (user == null)
            {
				TempData["Mesg"] = "Account does not exist";
				return View();
			}

			if (user.BlockedTo.HasValue && user.BlockedTo.Value >= DateTime.Now)
            {
				TempData["Mesg"] = $"Your account is locked to {user.BlockedTo.Value:dd/MM/yyyy HH:mm}";
				return View();
			}

			if (user.BlockedTo.HasValue && user.BlockedTo.Value <= DateTime.Now)
            {
                var data = await _db.FindAsync<AppUser>(user.Id);
                data.BlockedTo = null;
                data.BlockedBy = null;
                _db.Update(data);
                await _db.SaveChangesAsync();
            }

			var pwdHash = this.HashHMACSHA512WithKey(model.Password, user.PasswordSalt);
			if (!pwdHash.SequenceEqual(user.PasswordHash))
			{
				TempData["Mesg"] = "Username or password incorrect!!!";
				return View();
			}

			var claims = new List<Claim> {
							new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
							new Claim(ClaimTypes.Name, user.Username),
							new Claim(ClaimTypes.Email, user.Email),
							new Claim(AppClaimTypes.FullName, user.FullName),
							new Claim(AppClaimTypes.Avatar, user.Avatar),
							new Claim(AppClaimTypes.PhoneNumber, user.PhoneNumber1),
							new Claim(AppClaimTypes.RoleName, user.RoleName),
							new Claim(AppClaimTypes.RoleId, user.AppRoleId.ToString()),
							new Claim(AppClaimTypes.Permissions, user.Permission),
						};

			var claimsIdentity = new ClaimsIdentity(claims, AppConst.COOKIES_AUTH);
			var principal = new ClaimsPrincipal(claimsIdentity);
			var authenPropeties = new AuthenticationProperties()
			{
				ExpiresUtc = DateTime.UtcNow.AddHours(AppConst.LOGIN_TIMEOUT),
				IsPersistent = model.RememberMe
			};
			await HttpContext.SignInAsync(AppConst.COOKIES_AUTH, principal, authenPropeties);

			var returnUrl = Request.Query["ReturnUrl"].ToString();
			if (returnUrl.IsNullOrEmpty())
			{
				return HomePage();
			}
			return Redirect(returnUrl);
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(AppConst.COOKIES_AUTH);
			return Redirect("/admin/account/login");
		}

		[Authorize(AuthenticationSchemes = AppConst.COOKIES_AUTH)]
		public async Task<IActionResult> MyProfile()
		{
			ViewBag.Title = "My profile";
			var dataUser = await _db.AppUser.FirstAsync(i => i.Id == CurrentUserId);
			AdminProfileVM dataUserVM = new();

			if (dataUser != null)
			{
				dataUserVM.Avatar = dataUser.Avatar;
				dataUserVM.Username = dataUser.Username;
				dataUserVM.FullName = dataUser.FullName;
				dataUserVM.Email = dataUser.Email;
				dataUserVM.PhoneNumber1 = dataUser.PhoneNumber1;
				dataUserVM.PhoneNumber2 = dataUser.PhoneNumber2;
				dataUserVM.Address = dataUser.Address;
			}
			return View(dataUserVM);
		}

		[HttpPost]
		[Authorize(AuthenticationSchemes = AppConst.COOKIES_AUTH)]
		public async Task<IActionResult> MyProfile(AdminProfileVM model)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg("You have not entered data yet!!!");
				return RedirectToAction(nameof(MyProfile));
			}
			try
			{
				var User = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == CurrentUserId);

				User.FullName = model.FullName;
				User.Email = model.Email;
				User.PhoneNumber1 = model.PhoneNumber1;
				User.PhoneNumber2 = model.PhoneNumber2;
				User.Address = model.Address;

				_db.SaveChanges();
				SetSuccessMesg("Successfully updated!");
			}
			catch (Exception ex)
			{
				SetErrorMesg("There was an error during processing, please try again later!!!");
			}
			return RedirectToAction(nameof(Logout));
		}
		[Authorize]
		public async Task<IActionResult> ChangePassword(AdminProfileVM model)
		{
			var user = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == CurrentUserId);
			var encryptPassword = this.HashHMACSHA512WithKey(model.Pwd, user.PasswordSalt);

			if (!encryptPassword.SequenceEqual(user.PasswordHash))
			{
				SetErrorMesg("The old password is incorrect!!!");
				return RedirectToAction(nameof(MyProfile));
			}

			if (model.ConfirmPassword != model.NewPwd)
			{
				SetErrorMesg("Confirmation password does not match!!!");
				return RedirectToAction(nameof(MyProfile));
			}

			var hashResult = this.HashHMACSHA512(model.NewPwd);
			user.PasswordHash = hashResult.Value;
			user.PasswordSalt = hashResult.Key;

			await _db.SaveChangesAsync();

			if (model.LogoutAfterChangePwd)
			{
				SetErrorMesg("Password changed successfully!!!");
				return RedirectToAction(nameof(Logout));
			}
			SetSuccessMesg("Password changed successfully!!!");
			return RedirectToAction(nameof(Logout));
		}

		[HttpPost]
		public async Task<IActionResult> ChangeAvt(AdminProfileVM model, [FromServices] IWebHostEnvironment env)
		{
			try
			{
				var User = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == CurrentUserId);
				UploadFile(model.AvatarUpload, env.WebRootPath);

				User.Avatar = UploadFile(model.AvatarUpload, env.WebRootPath);

				await _db.SaveChangesAsync();
				SetSuccessMesg("Successfully updated!");
			}

			catch (Exception ex)
			{
				SetErrorMesg("There was an error during processing, please try again later!!!");
			}
			return RedirectToAction(nameof(Logout));
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
			var res = "upload/img_avt/" + fName;

			// Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
			fName = Path.Combine(dir, "upload/img_avt", fName);

			// Tạo Stream để lưu file
			var stream = System.IO.File.Create(fName);
			file.CopyTo(stream);
			stream.Dispose(); // Giải phóng bộ nhớ

			return res;
		}
	}
}