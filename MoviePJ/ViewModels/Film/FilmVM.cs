using MoviePJ.Areas.Admin.ViewModels;
using MoviePJ.Entities;

namespace MoviePJ.ViewModels.Film
{
	public class FilmVM
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public string? AnotherName { get; set; }
		public string? Desc { get; set; }
		public string? Slug { get; set; }
		public string? Cover { get; set; }
		public int ReleaseYear { get; set; }
		public int? Time { get; set; }
		public int? EpisodeCount { get; set; }
		public string? TrailerPath { get; set; }
		public string Country { get; set; }
		public string Language { get; set; }
		public string StatusName { get; set; }
		public int? DisplayOrder { get; set; }
		public List<string> GenresName { get; set; }
		public List<string> Stars { get; set; }
		public List<ActorFilmVM> Actor { get; set; }
		public List<FilmmakerVM> Filmmaker { get; set; }
		public List<StudioFilmVM> Studio { get; set; }
		public List<EpisodeFilmVM> Episodes { get; set; }
		public AppStatus AppStatus { get; set; }
		public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
		public ICollection<AppFilmmaker> AppFilmmakers { get; set; }
		public ICollection<AppFilmActor> AppFilmActors { get; set; }
		public ICollection<AppStudioFilm> AppStudioFilms { get; set; }
		public ICollection<AppEpisode> AppEpisodes { get; set; }
		//public ICollection<AppComment> AppComments { get; set; }
	}
}
