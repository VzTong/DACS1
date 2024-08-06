using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MoviePJ.Attributes;

namespace MoviePJ.ViewModels.Account
{
	public class LoginClientVM
	{
		[AppRequired]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		[AppRequired]
		public string Password { get; set; }
	}
}
