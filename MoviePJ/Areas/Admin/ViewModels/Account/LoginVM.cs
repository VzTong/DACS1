using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoviePJ.Areas.Admin.ViewModels.Account
{
	public class LoginVM
	{
		public string Username { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DisplayName("Remember Password")]
		public bool RememberMe { get; set; }
	}
}
