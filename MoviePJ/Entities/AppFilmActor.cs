using MoviePJ.Entities.Base;
using static MoviePJ.Consts.DB;

namespace MoviePJ.Entities
{
	public class AppFilmActor : AppEntityBase
	{
		public int? AppActorId { get; set; }
		public int? AppFilmId {  get; set; }
		public AppActor AppActor { get; set; }
		public AppFilm AppFilm { get; set; }
	}
}
