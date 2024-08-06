using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppStatus : AppEntityBase
	{
        public AppStatus()
        {
            AppFilms = new HashSet<AppFilm>();
        }
        public string Name { get; set; }
		public string? Desc { get; set; }
		public ICollection<AppFilm> AppFilms { get; set; }
	}
}
