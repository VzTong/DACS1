using MoviePJ.Entities;
using System.Collections.Generic;

namespace MoviePJ.Areas.Admin.ViewModels.FilmStudio
{
	public class ListItemStudioVM : ListItemBaseVM
	{
		public string Cover { get; set; }
		public IFormFile? CoverUpload { get; set; }
		public string Name { get; set; }
	}
}
