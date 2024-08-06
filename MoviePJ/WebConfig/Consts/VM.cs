using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePJ.WebConfig.Consts
{
    public static class VM
    {
        public static class UserVM
        {
            public const short USERNAME_MINLEN = 4;
            public const short PWD_MINLEN = 4;
        }
        public static class RoleVM
        {
            public const string NEWID_REQUIRED_ERR_MESG = "A new role must be selected to convert";
            public const string PERMISSION_IDS_REQUIRED_ERR_MESG = "No permissions have been selected for this role";

            // Regex check chuỗi có đúng định dạng hay không (VD: 1111,2222,1002)
            public const string PERMISSION_IDS_REGEX = @"((?<!^,)\d+(,(?!$)|$))+";
            public const string PERMISSION_IDS_REGEX_ERR_MESG = "Invalid data, try refreshing the page";
        }
        public static class CategoryNewsVM
        {
            public const short MIN_LENGTH = 10;
        }
        public static class NewsVM
        {
            public const short MIN_LENGTH = 10;
        }
        public static class FilmGenreVM
        {
            public const short MIN_LENGTH = 1;
			public const string GENRE_IDS_REQUIRED_ERR_MESG = "No genre have been selected for this role";

		}
	}
}
