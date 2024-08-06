using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppEpisode : AppEntityBase
	{
		public int EpNumber {  get; set; }
		public string? Path { get; set; }
		public int? FilmId { get; set; }
		public AppFilm AppFilm { get; set; }
	}
}
