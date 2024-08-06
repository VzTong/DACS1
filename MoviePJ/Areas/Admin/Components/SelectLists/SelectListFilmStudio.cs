using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviePJ.Areas.Admin.Components.SelectLists
{
	public class SelectListFilmStudio : ViewComponent
	{
		protected readonly MoviePJ_DBContext _db;
		public SelectListFilmStudio(MoviePJ_DBContext db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedValue, string _for, bool allowNull)
		{
			var proCate = await _db.AppStudio
				.Select(x => new
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToListAsync();

			if (proCate == null || !proCate.Any())
			{
				// Xử lý khi proCate là null hoặc không có phần tử nào
				throw new Exception("StudioFilm is null or empty");
			}

			MultiSelectList listCategory;

			if (selectedValue == null)
			{
				listCategory = new MultiSelectList(proCate, "Id", "Name");
			}
			else
			{
				//var selectedValues = new int[] { (int)selectedValue };
				listCategory = new MultiSelectList(proCate, "Id", "Name", selectedValue);
			}
			System.Diagnostics.Debug.WriteLine($"listStudio has {listCategory.Count()} items.");

			ViewBag.filmStudio = listCategory;
			ViewBag.For = _for;
			ViewBag.AllowNull = allowNull;
			return View();
		}
	}
}
