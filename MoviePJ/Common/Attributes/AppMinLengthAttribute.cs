using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppMinLengthAttribute : MinLengthAttribute
    {
        public AppMinLengthAttribute(int length) : base(length)
        {
        }
    }
}
