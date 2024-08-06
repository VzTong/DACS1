using MoviePJ.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Attributes
{
    public class AppConfirmPwdAttribute : CompareAttribute
    {
        public AppConfirmPwdAttribute(string otherProperty = "Password") : base(otherProperty)
        {
        }
    }
}
