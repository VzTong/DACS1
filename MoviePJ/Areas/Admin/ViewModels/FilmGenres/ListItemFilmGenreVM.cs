using MoviePJ.Entities;
using System.Collections.Generic;

namespace MoviePJ.Areas.Admin.ViewModels.FilmGenres
{
	public class ListItemFilmGenreVM : ListItemBaseVM
	{
		public string Name { get; set; }
		public int CateLevel { get; set; }
		public bool HasChild { get; set; }
		public string? Description { get; set; }
		public int? ParentCateId { get; set; }
		public ICollection<ListItemFilmGenreVM> ChildCategories { get; set; }
	}
}
