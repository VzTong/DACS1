using MoviePJ.Entities;
using MoviePJ.WebConfig;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using MoviePJ.Components.CateMenu;

namespace App.Web.Components.CateMenu
{
	public class CateMenuViewComponent : ViewComponent
	{
		protected readonly MoviePJ_DBContext _db;

		public CateMenuViewComponent(MoviePJ_DBContext db)
		{
			_db = db;
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			var data = await _db.AppGenres
				.Where(x => x.DeletedDate == null && x.HasChild)
				.OrderBy(x => x.DisplayOrder)
				.Select(x => new CateMenuViewModel
				{
					Id = x.Id,	
					Name = x.Name,
					Slug = x.Slug,
					Childs = x.ChildCategories
							.Where(c => c.DeletedDate == null)
							.Select(y => new CateMenuViewModel
							{
								Id = y.Id,
								Name = y.Name,
								Slug = y.Slug
							}).ToList()
				})
				.ToListAsync();
			return View(data);
		}
	}
}
