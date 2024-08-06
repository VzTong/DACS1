using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppEmailAttribute : RegularExpressionAttribute
    {
        public AppEmailAttribute(string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$") : base(pattern)
        {
			/*
			^[^@\s]+@[^@\s]+\.[^@\s]+$
			 └─┬──┘ ┬       └┬┘
               |    |        Ký tự chấm (dấu chấm)
			   |    |    
			   │    Ký tự @
			   |
			   Phần này đảm bảo rằng chuỗi không chứa ký tự ‘@’ hoặc khoảng trắng (dấu cách, tab, xuống dòng)
			*/
		}
	}
}
