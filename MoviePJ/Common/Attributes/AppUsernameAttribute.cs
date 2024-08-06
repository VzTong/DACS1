using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppUsernameAttribute : RegularExpressionAttribute
    {
        public AppUsernameAttribute(string pattern = @"^(?!.*[_.]{2})[a-zA-Z0-9._]+$") : base(pattern)
        {
            /*
			^(?!.*[_.]{2})[a-zA-Z0-9._]+$
			 └─────┬─────┘└─────┬─────┘
				   │            chỉ chấp nhận chữ thường, chữ hoa, số và _.
				   |
				   không chấp nhận __ hoặc .. hoặc _. hoặc ._
			*/
        }
    }
}
