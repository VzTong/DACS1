using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
    public class AppStudioFilm : AppEntityBase
    {
        public int? FilmId { get; set; }
        public int StudioId { get; set; }
        public AppFilm AppFilm { get; set; }
        public AppStudio AppStudio { get; set; }
    }
}
