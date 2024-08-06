using MoviePJ.Entities.Base;
using static MoviePJ.Consts.DB;

namespace MoviePJ.Entities
{
	public class AppActor : AppEntityBase
	{
        public AppActor()
        {
            AppFilmActors = new HashSet<AppFilmActor>();
        }
        public string FullName { get; set; }
		public string? Avatar { get; set; }
		public ICollection<AppFilmActor> AppFilmActors { get; set; }
	}
}
