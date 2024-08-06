using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppFilmmaker : AppEntityBase
	{
		public int? FilmId { get; set; }
		public int? MakerId { get; set; }
		public AppFilm AppFilm { get; set; }
		public AppMaker AppMaker { get; set; }
	}
}
