using MoviePJ.Entities;

namespace MoviePJ.ViewModels.Film
{
	public class FilmGenreVM
	{
		public FilmGenreVM()
		{
			Childs = new HashSet<AppGenres>();
			AppGenresFilms = new HashSet<AppGenresFilm>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Desc { get; set; }
		public string? Slug { get; set; }
		public int CateLevel { get; set; }
		public bool HasChild { get; set; }
		public int? ParentCateId { get; set; }
		public AppGenres ParentCategory { get; set; }
		public ICollection<AppGenres> Childs { get; set; }
		public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
	}
}
