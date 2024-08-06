using Microsoft.AspNetCore.Mvc;
using MoviePJ.Common;
using MoviePJ.Entities;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MoviePJ.Controllers
{
	public class MoviePJControllerBase : Controller
	{
		protected readonly MoviePJ_DBContext _db;

        public MoviePJControllerBase(MoviePJ_DBContext db)
        {
            _db = db;
        }

        protected int currentUserID { get
                => Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));        
        }

		protected void SetSuccessMesg(string msg)
		{
			TempData["_SuccessMesg"] = msg;
		}

		protected void SetErrorMesg(string msg)
		{
			TempData["_ErrorMesg"] = msg;
		}

		protected byte[] HashHMACSHA512WithKey(string pwd, byte[] key)
		{
			HMACSHA512 hmac = new(key);
			var pwdByte = Encoding.UTF8.GetBytes(pwd);
			return hmac.ComputeHash(pwdByte);
		}

		protected HashResult HashHMACSHA512(string pwd)
		{
			var hashResult = new HashResult();
			HMACSHA512 hmac = new();
			var pwdByte = Encoding.UTF8.GetBytes(pwd);
			hashResult.Value = hmac.ComputeHash(pwdByte);
			hashResult.Key = hmac.Key;
			return hashResult;
		}
	}

	public class HashResult
	{
		public byte[] Value { get; set; }
		public byte[] Key { get; set; }
	}
}
