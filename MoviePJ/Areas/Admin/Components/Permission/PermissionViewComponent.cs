using MoviePJ.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviePJ.Areas.Admin.Components.Permission
{
    public class PermissionViewComponent : ViewComponent
    {
		protected readonly MoviePJ_DBContext _db;
		public PermissionViewComponent(MoviePJ_DBContext db)
        {
			_db = db;
		}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _db.MstPermission
                            .AsEnumerable()
                            .OrderByDescending(m => m.DisplayOrder)
						    .ThenByDescending(m => m.Id)
							.GroupBy(x => x.GroupName)
							.ToList();
            return View(data);
        }
    }
}
