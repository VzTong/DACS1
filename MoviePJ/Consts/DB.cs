namespace MoviePJ.Consts
{
	/// <summary>
	/// Class này đặt các ràng buộc về mặt dữ liệu cho Entities
	/// </summary>
	public class DB
	{
		public static class AppRole
		{
			public const string TABLE_NAME					= "AppRole";
			public const short NAME_LENGTH					= 200;
			public const short DESC_LENGTH					= 100;
		}

		public static class AppRolePermission
		{
			public const string TABLE_NAME					= "AppRolePermission";
		}

		public static class AppUser
		{
			public const string TABLE_NAME					= "AppUser";
			public const short USERNAME_LENGTH				= 200;
			public const short FULLNAME_LENGTH				= 100;
			public const short PWD_LENGTH					= 200;
			public const short EMAIL_LENGTH					= 200;
			public const short PHONE_LENGTH					= 20;
			public const short ADDRESS_LENGTH				= 100;
			public const short AVATAR_LENGTH				= 200;
		}
		
		public static class MstPermission
		{
			public const string TABLE_NAME					= "MstPermission";
			public const short CODE_LENGTH					= 50;
			public const short TABLE_LENGTH					= 50;
			public const short GROUPNAME_LENGHT				= 100;
			public const short DESC_LENGHT					= 100;
		}

		public static class AppNews
		{
			public const string TABLE_NAME					= "AppNews";
			public const string DEFAULT_DATE				= "GETDATE()";
			public const string DEFAULT_VALUE				= null;
			public const short COUNT						= 0;
			public const short TITLE_LENGTH					= 100;
			public const short SUMMARY_LENGTH				= 200;
			public const short COVER_LENGTH					= 200;
			public const short MAX_LENGTH					= 500;
			public const bool PUBLIC_NEWS					= true;
		}

		public static class AppActor
		{
			public const string TABLE_NAME					= "AppActor";
			public const short FULLNAME_LENGTH				= 100;
			public const short AVATAR_LENGTH				= 200;
		}

		public static class AppMaker
		{
			public const string TABLE_NAME					= "AppMaker";
			public const short FULLNAME_LENGTH				= 100;
			public const short AVATAR_LENGTH				= 200;
		}

		public static class AppStudio
		{
			public const string TABLE_NAME					= "AppStudio";
			public const short NAME_LENGTH					= 100;
			public const short COVER_LENGHT					= 200;
		}

		public static class AppGenres
		{
			public const string TABLE_NAME					= "AppGenres";
			public const short NAME_LENGTH					= 100;
			public const short DESC_LENGTH					= 100;
            public const short SLUG_CATEGORY				= 125;
            public const short LENGTH_LEVEL					= 5;
            public const bool DEFAULT_VALUE					= false;
        }

		public static class AppFilm
		{
			public const string TABLE_NAME					= "AppFilm";
			public const short NAME_LENGTH					= 100;
			public const short ANOTHERNAME_LENGTH			= 200;
			public const short DESC_LENGHT					= 1000;
			public const short SLUG_LENGTH					= 125;
			public const short COVER_LENGTH					= 200;
			public const short RELEASE_YEAR_LENGTH			= 4;
			public const short TIME_LENGTH					= 3;
			public const short COUNTRY_LENGTH				= 56;
			public const short LANGUAGE_LENGTH				= 50;
            public const short EP_LENGTH					= 5;
            public const bool  ISACTIVE						= true;
        }

		public static class AppStatus
		{
			public const string TABLE_NAME					= "AppStatus";
			public const short NAME_LENGTH					= 100;
			public const short DESC_LENGTH					= 100;
            public const short STATUS_PROCESSING			= 1;
            public const short STATUS_DONE					= 2;
            public const string STATUS_PROCESSING_NAME		= "In progress";
            public const string STATUS_DONE_NAME			= "Finished";
        }

		public static class AppEpisode
        {
			public const string TABLE_NAME					= "AppEpisode";
			public const short EPNUMBER_LENGTH				= 4;
		}

		public static class AppComment
        {
			public const string TABLE_NAME					= "AppComments";
			public const short COMMENT_LENGTH				= 150;
		}

		public static class AppCommentDetail
        {
			public const string TABLE_NAME					= "AppCommentDetail";
		}

		public static class AppFilmmaker
		{
			public const string TABLE_NAME					= "AppFilmmaker";
		}

		public static class AppFilmActors
        {
			public const string TABLE_NAME					= "AppFilmActors";
		}

		public static class AppStudioFilm
		{
			public const string TABLE_NAME					= "AppStudioFilm";
		}

		public static class AppGenresFilm
		{
			public const string TABLE_NAME					= "AppGenresFilm";
			public const short MOVIE						= 1;
			public const short ANIME						= 2;
			public const short FILM_ACTION					= 3;
			public const short FILM_ADVENTURE				= 4;
			public const short FILM_DRAMA					= 7;
			public const short FILM_SCIENCE_FICTION			= 14;
			public const short FILM_THRILLER				= 17;
			public const short FILM_SHOJO					= 20;
			public const short FILM_KODOMOMUKE				= 23;
			public const short FILM_MECHA					= 25;
			public const short FILM_ISEKAI					= 26;

		}
	}
}
