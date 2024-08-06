using MoviePJ.Entities;
using System.Collections.Generic;

namespace MoviePJ.Areas.Admin.ViewModels.Filmmaker
{
	public class ListItemMakersVM : ListItemBaseVM
	{
		public string Avatar { get; set; }
		public IFormFile? AvatarUpload { get; set; }
		public string FullName { get; set; }
	}
}
