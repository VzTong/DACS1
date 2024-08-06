using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppRegexAttribute : RegularExpressionAttribute
    {
        public AppRegexAttribute(string pattern) : base(pattern)
        {
        }
    }
}
