using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MoviePJ.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviePJ.Areas.Admin.Components.SelectLists
{
    public class SelectListFilmStatus : ViewComponent
    {
        protected readonly MoviePJ_DBContext _db;
        public SelectListFilmStatus(MoviePJ_DBContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? selectedValue, string _for, bool allowNull)
        {
            var proSatus = await _db.AppStatus
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            if (proSatus == null || !proSatus.Any())
            {
                // Xử lý khi proSatus là null hoặc không có phần tử nào
                throw new Exception("Status is null or empty");
            }

            SelectList listCategory;

            if (selectedValue == null)
            {
                listCategory = new SelectList(proSatus, "Id", "Name");
            }
            else
            {
                var selectedValues = new int[] { (int)selectedValue };
                listCategory = new SelectList(proSatus, "Id", "Name", selectedValue);
            }
            ViewBag.filmStatus = listCategory;
            ViewBag.For = _for;
            ViewBag.AllowNull = allowNull;
            return View();
        }
    }
}
