using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppMaxLengthAttribute : MaxLengthAttribute
    {
        public AppMaxLengthAttribute() : base()
        {
        }

        public AppMaxLengthAttribute(int length) : base(length)
        {
        }
    }
}
