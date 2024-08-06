using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using Microsoft.EntityFrameworkCore;
using MoviePJ.WebConfig.Consts;


namespace MoviePJ.Areas.Admin.Components.ListRole
{
	public class ListRoleViewComponent : ViewComponent
	{
		protected readonly MoviePJ_DBContext _db;

		public ListRoleViewComponent(MoviePJ_DBContext db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync(int? seletetedId)
		{	
			var data = await _db.AppRole.Where(r => r.DeletedDate == null && r.Id != AppConst.ROLE_ADMINISTRATOR_ID)
										.OrderByDescending(r => r.DisplayOrder)
										.ThenByDescending(r => r.Id)
										.ToListAsync();

			ViewBag.SelectedId = seletetedId;
			return View(data);
		}
	}
}
