using MoviePJ.Entities;

namespace MoviePJ.ViewModels.Film
{
	public class EpisodeFilmVM
	{
		public int EpNumber { get; set; }
		public string? Path { get; set; }
		public int? FilmId { get; set; }
		public AppFilm AppFilm { get; set; }
	}
}
