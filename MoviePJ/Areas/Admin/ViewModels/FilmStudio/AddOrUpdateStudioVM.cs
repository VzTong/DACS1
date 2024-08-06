using MoviePJ.Attributes;
using MoviePJ.Consts;
using MoviePJ.WebConfig.Consts;

namespace MoviePJ.Areas.Admin.ViewModels.FilmStudio
{
	public class AddOrUpdateStudioVM
	{
		public int? Id { get; set; }

		[AppRequired]
		[AppStringLength(VM.FilmGenreVM.MIN_LENGTH, DB.AppStudio.NAME_LENGTH)]
		public string Name { get; set; }
		public string? Cover { get; set; }
		public IFormFile? CoverUpload { get; set; }

	}
}
