using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.ViewModels.Account;
using MoviePJ.WebConfig.Consts;
using NuGet.Protocol.Core.Types;
using System.Security;
using System.Security.Claims;

namespace MoviePJ.Controllers
{
	public class AccountController : MoviePJControllerBase
	{
		private readonly string DefaultImagePath = "upload/img_avt/avt_default.png";// Đường dẫn đến ảnh mặc định
		public readonly INotyfService _notyf;

		public AccountController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[HttpGet]
		public IActionResult Register() => View();

		[HttpPost]
		public async Task<IActionResult> Register(string Username, string Password, string ConfirmPwd, [FromServices] IWebHostEnvironment env)
		{
			RegisterVM model = new();
			model.Username = Username;
			model.Password = Password;
			model.ConfirmPwd = ConfirmPwd;

			if (model.ConfirmPwd != model.Password)
			{
				_notyf.Error("Confirmation password does not match!!!");
				return RedirectToAction(nameof(Index), "Home");
			}

			if (!ModelState.IsValid)
			{
				_notyf.Error("Invalid data, please check again!");
				return RedirectToAction(nameof(Index), "Home");
			}

			// Chuẩn hóa username
			model.Username = model.Username.ToLower().Trim();
			// Check username đã tồn tại chưa
			var exists = await _db.AppUser.AnyAsync(u => u.Username == model.Username);
			if (exists)
			{
				_notyf.Error("Username already exists, please check again!");
				return RedirectToAction(nameof(Index), "Home");
			}
			try
			{
				var hashResult = HashHMACSHA512(model.Password);
				model.PasswordHash = hashResult.Value;
				model.PasswordSalt = hashResult.Key;

				AppUser user = new();
				user.Username = model.Username;
				user.CreatedDate = DateTime.Now;
				user.Avatar = DefaultImagePath.TrimStart('/');
				user.PasswordHash = model.PasswordHash;
				user.PasswordSalt = model.PasswordSalt;
				user.AppRoleId = AppConst.ROLE_CUSTOMER_ID;
				await _db.AppUser.AddAsync(user);
				await _db.SaveChangesAsync();

				_notyf.Success($"Added account [{user.Username}] successfully");
				return RedirectToAction(nameof(Index), "Home");
			}
			catch (Exception ex)
			{
				return RedirectToAction(nameof(Index), "Home");
			}
		}

		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginClientVM model)
		{
			//LoginClientVM model = new();

			//model.Username = Username;
			//model.Password = Password;

			if (!ModelState.IsValid)
			{
				_notyf.Error("You have not entered data yet");
				return RedirectToAction(nameof(Index), "Home");
			}

			var username = await _db.AppUser.SingleOrDefaultAsync(u => u.Username.ToLower() == model.Username.ToLower());


			if (username is null)
			{
				_notyf.Error("Account does not exist");
				return RedirectToAction(nameof(Index), "Home");
			}


			var user = _db.AppUser
						.Where(u => u.Username.ToLower() == model.Username.ToLower())
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

			if (user.BlockedTo.HasValue && user.BlockedTo.Value >= DateTime.Now)
			{
				_notyf.Error($"Your account is locked to {user.BlockedTo.Value:dd/MM/yyyy HH:mm}");
				return RedirectToAction("Index", "Home");
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
				_notyf.Error("Username or password incorrect!!!");
				return RedirectToAction(nameof(Index), "Home");
			}

			// Đăng nhập theo chuẩn MVC
			// Dùng Cookies
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
				IsPersistent = true
			};
			await HttpContext.SignInAsync(AppConst.COOKIES_AUTH, principal, authenPropeties);

			_notyf.Success("Logged in successfully");
			return RedirectToAction(nameof(Index), "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(AppConst.COOKIES_AUTH);
			return RedirectToAction("Index", "Home");
		}

		[Route("/user-profile")]
		[Authorize]
		public async Task<IActionResult> UserProfile()
		{
			var dataUser = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == currentUserID);
			UserProfileClientVM dataUserVM = new();

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

		[Authorize]
		[HttpPost("/user-profile")]
		public async Task<IActionResult> UserProfile(UserProfileClientVM model)
		{
			if (!ModelState.IsValid)
			{
				_notyf.Error("You have not entered data yet!!!");
				return RedirectToAction(nameof(UserProfile));
			}

			try
			{
				var User = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == currentUserID);

				User.FullName = model.FullName;
				User.Email = model.Email;
				User.PhoneNumber1 = model.PhoneNumber1;
				User.PhoneNumber2 = model.PhoneNumber2;
				User.Address = model.Address;

				_db.SaveChanges();
				_notyf.Success("Successfully updated!");
			}
			catch (Exception ex)
			{
				_notyf.Error("There was an error during processing, please try again later!!!");
			}
			return RedirectToAction(nameof(UserProfile));
		}

		[Authorize]
		public async Task<IActionResult> ChangePassword(UserProfileClientVM model)
		{
			var user = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == currentUserID);
			var encryptPassword = this.HashHMACSHA512WithKey(model.Pwd, user.PasswordSalt);
			//if (!ModelState.IsValid)
			//{
			//	return RedirectToActionPermanent(nameof(UserProfile));

			//}

			if (!encryptPassword.SequenceEqual(user.PasswordHash))
			{
				_notyf.Error("The old password is incorrect!!!");
				return RedirectToAction(nameof(UserProfile));
			}

			if (model.ConfirmPassword != model.NewPwd)
			{
				_notyf.Error("Confirmation password does not match!!!");
				return RedirectToAction(nameof(UserProfile));
			}

			var hashResult = this.HashHMACSHA512(model.NewPwd);
			user.PasswordHash = hashResult.Value;
			user.PasswordSalt = hashResult.Key;

			await _db.SaveChangesAsync();

			if (model.LogoutAfterChangePwd)
			{
				_notyf.Success("Password changed successfully!!!");
				return RedirectToAction(nameof(Logout));
			}

			_notyf.Success("Password changed successfully!!!");
			return RedirectToAction(nameof(UserProfile));
		}

		[HttpPost]
		public async Task<IActionResult> ChangeAvt(UserProfileClientVM model, [FromServices] IWebHostEnvironment env)
		{
			try
			{
				var User = await _db.AppUser.FirstOrDefaultAsync(i => i.Id == currentUserID);
				UploadFile(model.AvatarUpload, env.WebRootPath);

				User.Avatar = UploadFile(model.AvatarUpload, env.WebRootPath);

				await _db.SaveChangesAsync();
				_notyf.Success("Successfully updated!");
			}

			catch (Exception ex)
			{
				_notyf.Error("There was an error during processing, please try again later!!!");
			}
			return RedirectToAction(nameof(UserProfile));
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
