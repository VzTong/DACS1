using MoviePJ.Entities;
using MoviePJ.Areas.Admin.ViewModels.FilmGenres;
using MoviePJ.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MoviePJ.Areas.Admin.Components.ListFilmGenre
{
    public class SelectListFilmGenre : ViewComponent
    {
        protected readonly MoviePJ_DBContext _db;

        public SelectListFilmGenre(MoviePJ_DBContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _db.AppGenres
                .Include(s => s.AppGenresFilms)
                .ThenInclude(s => s.AppFilm)
                .Include(s => s.ChildCategories)
                .ThenInclude(s => s.AppGenresFilms)
                .ThenInclude(s => s.AppFilm)
                .Where(s => s.CateLevel.Equals(1) && s.DeletedDate == null)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
            return View(data);
        }
    }
}
