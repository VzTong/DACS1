using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
    public class AppStudio : AppEntityBase
    {
        public AppStudio()
        {
            AppStudioFilms = new HashSet<AppStudioFilm>();
        }
        public string Name { get; set; }
        public string? Cover { get; set; }
        public ICollection<AppStudioFilm> AppStudioFilms { get; set; }
    }
}
