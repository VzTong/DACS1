using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppRole : AppEntityBase
	{
		public AppRole()
		{
			AppUsers = new HashSet<AppUser>();
			AppRolePermissions = new HashSet<AppRolePermission>();
		}
		public string Name { get; set; }
		public string? Desc { get; set; }
        public bool? CanDelete { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }
		public ICollection<AppRolePermission> AppRolePermissions { get; set; }
	}
}
