using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviePJ.Areas.Admin.ViewModels.Role;
using MoviePJ.Common;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.Entities.Base;
using MoviePJ.Extensions;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using System.Data;
using X.PagedList;

namespace MoviePJ.Areas.Admin.Controllers
{
	public class RoleController : AppControllerBase
	{
		public readonly INotyfService _notyf;
		protected const int PAGE_SIZE = 10;

		public RoleController(MoviePJ_DBContext db, INotyfService notyf) : base(db)
		{
			_notyf = notyf;
		}

		[AppAuthorize(AuthConst.AppRole.VIEW_LIST)]
		public async Task<IActionResult> Index(int page = 1, int size = PAGE_SIZE)
		{
			var data = (await _db.AppRole
									.Where(m => m.DeletedDate == null)
									.Select(m => new RoleListItemVM
									{
										Id = m.Id,
										Name = m.Name,
										Desc = m.Desc,	
										CreatedDate = m.CreatedDate,
									})
									.OrderByDescending(m => m.Id)
									.ToPagedListAsync(page, size))
									.GenRowIndex();
			return View(data);
		}

		[AppAuthorize(AuthConst.AppRole.CREATE)]
		public IActionResult Create() => View();

		[HttpPost]
		[AppAuthorize(AuthConst.AppRole.CREATE)]
		public async Task<IActionResult> Create(RoleAddVM model)
		{
			if (model.PermissionIds == null)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG);
				return View(model);
			}
			var arrIdPermission = model.PermissionIds.Split(',');

			var role = new AppRole
			{
				Name = model.Name,
				Desc = model.Desc,
				CreatedBy = CurrentUserId,
				CreatedDate = DateTime.Now
			};
			try
			{
				await _db.AddAsync(role);
				foreach (var item in arrIdPermission)
				{
					var idPer = Convert.ToInt32(item);
					role.AppRolePermissions.Add(new AppRolePermission
					{
						MstPermissionId = idPer
					});
				}

				await _db.AddRangeAsync(role.AppRolePermissions);
				await _db.SaveChangesAsync();

				SetSuccessMesg($"Added role ⌈ {role.Name} ⌋ successfully");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				//LogException(ex);
				SetErrorMesg(EXCEPTION_ERR_MESG);
				return View();
			}
		}

		[AppAuthorize(AuthConst.AppRole.UPDATE)]
		public async Task<IActionResult> Edit(int? id)
		{
			if (!id.HasValue)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			var data = await _db.AppRole
									.Include(r => r.AppRolePermissions)
									.Where(r => r.Id == id.Value)
									.Select(r => new RoleEditVM
									{
										Id = r.Id,
										Name = r.Name,
										Desc = r.Desc,
										PermissionIds = string.Join(',', r.AppRolePermissions.Select(rp => rp.MstPermissionId))
									}).SingleOrDefaultAsync();
			if (data == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			return View(data);
		}

		[HttpPost]
		[AppAuthorize(AuthConst.AppRole.UPDATE)]
		public async Task<IActionResult> Edit(RoleEditVM model)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			var role = await _db.FindAsync<AppRole>(model.Id);
			var curPermisssionIds = _db.AppRolePermission
											.Where(s => s.AppRoleId == role.Id)
											.ToList();
			if (role == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			// danh sách permission bị xóa khỏi role
			var deletedPermissionIds = model.DeletedPermissionIds.IsNullOrEmpty() ? null : model.DeletedPermissionIds.Split(',').Select(i => Convert.ToInt32(i));
			// danh sách permission được thêm vào role
			var addedPermissionIds = model.AddedPermissionIds.IsNullOrEmpty() ? null : model.AddedPermissionIds.Split(',').Select(i => Convert.ToInt32(i)).OrderBy(i => i);
			// danh sách permission hiện tại
			var rolePermissionIds = curPermisssionIds
								.Where(x => deletedPermissionIds != null && deletedPermissionIds.Contains(x.MstPermissionId))
								.Select(x => x.Id)
								.OrderBy(x => x);
			// nếu xóa hết permission mà không thêm mới thì không cho thêm
			if ((addedPermissionIds == null || !addedPermissionIds.Any()) && deletedPermissionIds != null && rolePermissionIds.SequenceEqual(deletedPermissionIds))
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG);
				return RedirectToAction(nameof(Edit), new { id = model.Id });
			}

			if (deletedPermissionIds != null && deletedPermissionIds.Any())
			{
				if (rolePermissionIds == null || !rolePermissionIds.Any())
				{
					throw new Exception("Empty ID list");
				}

				foreach (var id in rolePermissionIds)
				{
					var entity = await _db.AppRolePermission.FindAsync(id);
					if (entity != null)
					{
						_db.AppRolePermission.Remove(entity);
					}
				}

				await _db.SaveChangesAsync();
			}

			if (addedPermissionIds != null && addedPermissionIds.Any())
			{
				var addedRolePermisson = new List<AppRolePermission>();
				foreach (var item in addedPermissionIds)
				{
					addedRolePermisson.Add(new AppRolePermission
					{
						AppRoleId = role.Id,
						MstPermissionId = item
					});
				}
				await _db.AddRangeAsync(addedRolePermisson);
			}
			role.Name = model.Name;
			role.Desc = model.Desc;
			role.UpdatedDate = DateTime.Now;
			role.UpdatedBy = CurrentUserId;
			_db.UpdateRange(role);
			await _db.SaveChangesAsync();
			SetSuccessMesg($"Update of role ⌈ {role.Name} ⌋ succeeded");
			return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
		}

		[AppAuthorize(AuthConst.AppRole.DELETE)]
		public async Task<IActionResult> Delete(int? id)
		{
			if (!id.HasValue)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var data = await _db.AppRole.Where(r => r.Id == id.Value)
										.Select(r => new RoleDeleteVM
										{
											Id = r.Id,
											Name = r.Name,
											Desc = r.Desc,
										})
										.SingleOrDefaultAsync();
			if (data == null)
			{
				SetErrorMesg(PAGE_NOT_FOUND_MESG);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			if (data.CanDelete == false)
			{
				SetErrorMesg($"Cannot delete role ⌈ {data.Name} ⌋");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			// Xóa không cần xác nhận nếu không có dữ liệu user liên quan
			if (data.AppUsers == null || data.AppUsers.Count == 0)
			{
				var entity = await _db.AppRole.FindAsync(data.Id);
				if (entity != null)
				{
					// Đánh dấu bản ghi là đã xóa
					entity.DeletedDate = DateTime.Now;
					entity.UpdatedBy = CurrentUserId; // Nếu có thông tin người cập nhật

					// Lưu thay đổi vào cơ sở dữ liệu
					await _db.SaveChangesAsync();
				}
				SetSuccessMesg($"Deletion of role ⌈ {data.Name} ⌋ succeeded");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			var userDeletedCount = data.AppUsers.Where(u => u.DeletedDate != null).Count();
			if (userDeletedCount == data.AppUsers.Count)
			{
				var entity = await _db.AppRole.FindAsync(data.Id);
				if (entity != null)
				{
					// Đánh dấu bản ghi là đã xóa
					entity.DeletedDate = DateTime.Now;
					entity.UpdatedBy = CurrentUserId; // Nếu có thông tin người cập nhật

					// Lưu thay đổi vào cơ sở dữ liệu
					await _db.SaveChangesAsync();
				}
				var users = await _db.AppUser.Where(u => u.AppRoleId == data.Id).ToListAsync();
				// Cập nhật vai trò mới
				users.ForEach(u => u.AppRoleId = null);
				_db.UpdateRange(users);
				await _db.SaveChangesAsync();
				SetSuccessMesg($"Deletion of role ⌈ {data.Name} ⌋ succeeded");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			// Chỉ hiển thị user chưa bị xóa
			data.AppUsers = data.AppUsers.Where(u => u.DeletedDate == null).ToList();
			return View(data);
		}

		[HttpPost]
		[AppAuthorize(AuthConst.AppRole.DELETE)]
		public async Task<IActionResult> Delete(RoleDeleteVM data)
		{
			if (!ModelState.IsValid)
			{
				SetErrorMesg(MODEL_STATE_INVALID_MESG, true);
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}

			try
			{
				var users = await _db.AppUser.Where(u => u.AppRoleId == data.Id).ToListAsync();
				// Cập nhật vai trò mới
				users.ForEach(u => u.AppRoleId = data.NewId);

				await _db.Database.BeginTransactionAsync();

				// Cập nhật role mới cho users
				_db.UpdateRange(users);
				await _db.SaveChangesAsync();
				// Xóa role cũ
				var entity = await _db.AppRole.FindAsync(data.Id);
				if (entity != null)
				{
					// Đánh dấu bản ghi là đã xóa
					entity.DeletedDate = DateTime.Now;
					entity.UpdatedBy = CurrentUserId; // Nếu có thông tin người cập nhật

					// Lưu thay đổi vào cơ sở dữ liệu
					await _db.SaveChangesAsync();
				}
				await _db.Database.CommitTransactionAsync();

				SetSuccessMesg($"Deletion of role ⌈  {data.Name}  ⌋ succeeded");
				return RedirectToAction(nameof(Index), ROUTE_FOR_AREA);
			}
			catch (Exception ex)
			{
				// Rollback
				await _db.Database.RollbackTransactionAsync();

				SetErrorMesg(EXCEPTION_ERR_MESG);
				//LogException(ex);
				return RedirectToAction(nameof(Delete), new { id = data.Id });
			}
		}

	}
}
