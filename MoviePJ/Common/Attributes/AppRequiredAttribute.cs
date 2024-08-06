using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppRequiredAttribute : RequiredAttribute
    {
        public AppRequiredAttribute() : base()
        {
        }
    }
}
