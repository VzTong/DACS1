using MoviePJ.Attributes;
using MoviePJ.Consts;
using MoviePJ.WebConfig.Consts;

namespace MoviePJ.Areas.Admin.ViewModels.FilmGenres
{
	public class AddOrUpdateFilmGenreVM
	{
		public int? Id { get; set; }

		[AppRequired]
		[AppStringLength(VM.FilmGenreVM.MIN_LENGTH, DB.AppGenres.NAME_LENGTH)]
		public string Name { get; set; }

		public string? Desc { get; set; }

		public string? Slug { get; set; }

		public int? ParentCateId { get; set; }

	}
}
