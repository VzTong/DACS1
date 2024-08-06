using MoviePJ.Entities;
using MoviePJ.ViewModels.Film;

namespace MoviePJ.Areas.Admin.ViewModels.User
{
	public class UserListItemVM : ListItemBaseVM
	{
		public string Username { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber1 { get; set; }
		public string Email { get; set; }
		public DateTime? BlockedTo { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string RoleName { get; set; }
		public bool IsBlock
		{
			get
			{
				var now = DateTime.Now;
				if (BlockedTo.HasValue && BlockedTo > now)
				{
					return true;
				}
				return false;
			}
		}
	}
}
