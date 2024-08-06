using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviePJ.Entities;

namespace MoviePJ.Areas.Admin.Components.SelectLists
{
	public class SelectListFilmActor : ViewComponent
	{
		protected readonly MoviePJ_DBContext _db;
		public SelectListFilmActor(MoviePJ_DBContext db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedValue, string _for, bool allowNull)
		{
			var proCate = await _db.AppActors
				.Select(x => new
				{
					Id = x.Id,
					Name = x.FullName
				})
				.ToListAsync();

			if (proCate == null || !proCate.Any())
			{
				// Xử lý khi proCate là null hoặc không có phần tử nào
				throw new Exception("ActorFilm is null or empty");
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
			System.Diagnostics.Debug.WriteLine($"listActor has {listCategory.Count()} items.");

			ViewBag.filmActor = listCategory;
			ViewBag.For = _for;
			ViewBag.AllowNull = allowNull;
			return View();
		}
	}
}
