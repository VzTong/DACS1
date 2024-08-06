using MoviePJ.Areas.Admin.ViewModels;
using MoviePJ.Entities;

namespace MoviePJ.ViewModels.Film
{
	public class ListItemFilmVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? AnotherName { get; set; }
		public string? Desc { get; set; }
		public string? Slug { get; set; }
		public string? Cover { get; set; }
		public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
	}
}
