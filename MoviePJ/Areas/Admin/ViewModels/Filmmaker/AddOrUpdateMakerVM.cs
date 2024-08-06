using MoviePJ.Attributes;
using MoviePJ.Consts;
using MoviePJ.WebConfig.Consts;

namespace MoviePJ.Areas.Admin.ViewModels.Filmmaker
{
	public class AddOrUpdateFilmmakerVM
	{
		public int? Id { get; set; }

		[AppRequired]
		[AppStringLength(VM.FilmGenreVM.MIN_LENGTH, DB.AppMaker.FULLNAME_LENGTH)]
		public string FullName { get; set; }
		public string? Avatar { get; set; }
		public IFormFile? AvatarUpload { get; set; }

	}
}
