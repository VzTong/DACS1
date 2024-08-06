using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppGenresFilm : AppEntityBase
	{
		public int? GenresId { get; set; }
		public int? FilmId { get; set; }
		public AppGenres AppGenres { get; set; }
		public AppFilm AppFilm { get; set; }
	}
}
