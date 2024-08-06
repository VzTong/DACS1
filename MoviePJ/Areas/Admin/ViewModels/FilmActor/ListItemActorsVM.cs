using MoviePJ.Entities;
using System.Collections.Generic;

namespace MoviePJ.Areas.Admin.ViewModels.FilmActor
{
	public class ListItemActorsVM : ListItemBaseVM
	{
		public string Avatar { get; set; }
		public IFormFile? AvatarUpload { get; set; }
		public string FullName { get; set; }
	}
}
