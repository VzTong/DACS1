using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
    public class AppMaker : AppEntityBase
    {
        public AppMaker()
        {
            AppFilmmakers = new HashSet<AppFilmmaker>();
        }
        public string FullName { get; set; }
        public string? Avatar { get; set; }
        public ICollection<AppFilmmaker> AppFilmmakers { get; set; }
    }
}
