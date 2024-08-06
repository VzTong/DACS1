using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviePJ.Areas.Admin.Components.SelectLists
{
	public class SelectListFilmMaker : ViewComponent
	{
		protected readonly MoviePJ_DBContext _db;
		public SelectListFilmMaker(MoviePJ_DBContext db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedValue, string _for, bool allowNull)
		{
			var proCate = await _db.AppMaker
				.Select(x => new
				{
					Id = x.Id,
					Name = x.FullName
				})
				.ToListAsync();

			if (proCate == null || !proCate.Any())
			{
				// Xử lý khi proCate là null hoặc không có phần tử nào
				throw new Exception("MakerFilm is null or empty");
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
			System.Diagnostics.Debug.WriteLine($"listMaker has {listCategory.Count()} items.");

			ViewBag.filmMaker = listCategory;
			ViewBag.For = _for;
			ViewBag.AllowNull = allowNull;
			return View();
		}
	}
}
