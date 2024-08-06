using MoviePJ.Entities.Base;
using System.Security.Claims;

namespace MoviePJ.Entities
{
	public class AppUser : AppEntityBase
	{
		public AppUser()
		{
			AppNews = new HashSet<AppNews>();
			AppCommentDetails = new HashSet<AppCommentDetail>();
		}
		public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string? FullName { get; set; }
		public string? PhoneNumber1 { get; set; }
		public string? PhoneNumber2 { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
		public string? Avatar { get; set; }
		public DateTime? BlockedTo { get; set; }
		public int? BlockedBy { get; set; }
		public int? AppRoleId { get; set; }
		public AppRole AppRole { get; set; }
		public ICollection<AppCommentDetail> AppCommentDetails { get; set; }
		public ICollection<AppNews> AppNews { get; set; }
	}
}
