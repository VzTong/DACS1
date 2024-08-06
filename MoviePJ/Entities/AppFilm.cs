using MoviePJ.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MoviePJ.Consts.DB;

namespace MoviePJ.Entities
{
	public class AppFilm : AppEntityBase
	{
        public AppFilm()
        {
            AppEpisodes = new HashSet<AppEpisode>();
            AppGenresFilms = new HashSet<AppGenresFilm>();
            AppFilmmakers = new HashSet<AppFilmmaker>();
            AppFilmActors = new HashSet<AppFilmActor>();
            AppStudioFilms = new HashSet<AppStudioFilm>();
            AppComments = new HashSet<AppComment>();
        }
        public string Name { get; set; }
		public string? AnotherName { get; set; }
		public string? Desc {  get; set; }
		public string? Slug { get; set; }
		public string? Cover { get; set; }
		public int ReleaseYear { get; set; }
		public int? Time { get; set; }
        public int? EpisodeCount { get; set; }
        public string? TrailerPath { get; set; }
        public string Country { get; set; }
		public string Language { get; set; }
		public bool IsActive { get; set; }
		public int? StatusId { get; set; }
		public AppStatus AppStatus { get; set; }
        public ICollection<AppStudioFilm> AppStudioFilms { get; set; }
        public ICollection<AppFilmmaker> AppFilmmakers { get; set; }
        public ICollection<AppEpisode> AppEpisodes { get; set; }
        public ICollection<AppComment> AppComments { get; set; }
		public ICollection<AppFilmActor> AppFilmActors { get; set; }
		public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
	}
}
