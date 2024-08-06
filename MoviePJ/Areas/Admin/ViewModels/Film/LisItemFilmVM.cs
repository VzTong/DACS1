using MoviePJ.Entities;
using MoviePJ.ViewModels.Film;

namespace MoviePJ.Areas.Admin.ViewModels.Film
{
	public class ListItemFilmVM : ListItemBaseVM
	{
		public string Name { get; set; }
		public string? AnotherName { get; set; }
		public string? Desc { get; set; }
		public string? Slug { get; set; }
		public string? Cover { get; set; }
		public int ReleaseYear { get; set; }
		public int? Time { get; set; }
		public int? EpisodeCount { get; set; }
		public string? TrailerPath { get; set; }
		public string Country { get; set; }
		public string Language { get; set; }
		public string StatusName { get; set; }
		public bool IsActive { get; set; }
		public int? DisplayOrder { get; set; }
		public List<int>? GenreId { get; set; }
		public List<string> GenresName { get; set; }
		public AppStatus AppStatus { get; set; }
		public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
	}
}
