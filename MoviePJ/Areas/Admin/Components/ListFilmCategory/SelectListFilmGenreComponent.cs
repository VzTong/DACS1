using MoviePJ.Entities;
using MoviePJ.Areas.Admin.ViewModels.FilmGenres;
using MoviePJ.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePJ.Areas.Admin.Components.ListFilmGenre
{
    public class SelectListFilmGenreComponent : ViewComponent
    {
        protected readonly MoviePJ_DBContext _db;
        public SelectListFilmGenreComponent(MoviePJ_DBContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(AddOrUpdateFilmGenreVM filmGenre)
        {
            var fimGenre = await _db.AppGenres
                .Where(s => s.CateLevel.Equals(1))
                .Where(s => s.DeletedDate == null)
                .Include(s => s.ChildCategories)
                .ToListAsync();

            var listItemFilmVMs = fimGenre.Select(genre =>
                                new ListItemFilmGenreVM
								{
                                    Id = genre.Id,
                                    // Thực hiện ánh xạ các thuộc tính khác tùy theo nhu cầu của bạn
                                    Name = genre.Name,
                                    Description = genre.Desc,
                                    ParentCateId = genre.ParentCateId,
                                    CateLevel = genre.CateLevel,
                                    HasChild = genre.HasChild,
                                    
                                    // Ánh xạ thuộc tính con nếu cần
                                    ChildCategories = genre.ChildCategories?.Select(child =>
                                        new ListItemFilmGenreVM
										{
                                            Id = child.Id,
                                            Name = child.Name,
                                            Description = child.Desc

                                        }).ToList()

                                }).ToList();


            var listCategory = new SelectList(listItemFilmVMs, "Id", "CateLevel", -1);
            if (filmGenre != null)
            {
                listCategory = new SelectList(listItemFilmVMs, "Id", "CateLevel", filmGenre.ParentCateId);
            };
            ViewBag.filmGenre = listCategory;
            return View(filmGenre);
        }
    }
}
