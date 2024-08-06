using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppRangeAttribute : RangeAttribute
    {
        public AppRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
        }
    }
}
