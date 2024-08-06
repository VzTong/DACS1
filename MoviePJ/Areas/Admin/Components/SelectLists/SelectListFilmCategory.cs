using MoviePJ.Entities;
using MoviePJ.Areas.Admin.ViewModels.Film;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePJ.Areas.Admin.Components.SelectLists
{
    public class SelectListFilmCategory : ViewComponent
    {
        protected readonly MoviePJ_DBContext _db;
        public SelectListFilmCategory(MoviePJ_DBContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedValue, string _for, bool allowNull)
        {
            var proCate = await _db.AppGenres
                .Where(s => s.CateLevel.Equals(2))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = (x.ParentCategory != null ? x.ParentCategory.Name + " - " : "") + x.Name
                })
                .ToListAsync();

            if (proCate == null || !proCate.Any())
            {
                // Xử lý khi proCate là null hoặc không có phần tử nào
                throw new Exception("proCate is null or empty");
            }

            MultiSelectList listCategory;

            if (selectedValue == null)
            {
                listCategory = new MultiSelectList(proCate, "Id", "Name");
            }
            else
            {
                //var selectedValues = new int[] { selectedValue. };
                listCategory = new MultiSelectList(proCate, "Id", "Name", selectedValue);
            }

            ViewBag.filmGenre = listCategory;
            ViewBag.For = _for;
            ViewBag.AllowNull = allowNull;
            return View();
        }
    }
}
