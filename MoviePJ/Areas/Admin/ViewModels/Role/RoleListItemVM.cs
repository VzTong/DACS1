namespace MoviePJ.Areas.Admin.ViewModels.Role
{
	public class RoleListItemVM : ListItemBaseVM
	{
		public string Name { get; set; }
		public string? Desc { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
