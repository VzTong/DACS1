namespace MoviePJ.Consts
{
	public class AuthConst
	{
        public const int NO_PERMISSION = -1;
        public static class AppUser
		{
			public const int VIEW_LIST						= 1001;
			public const int VIEW_DETAIL					= 1002;
			public const int CREATE							= 1003;
			public const int UPDATE							= 1004;
            public const int UPDATE_PWD						= 1005;
            public const int BLOCK							= 1006;
            public const int UNBLOCK						= 1007;

        }

		public static class AppRole
		{
			public const int VIEW_LIST						= 1101;
			public const int VIEW_DETAIL					= 1102;
			public const int CREATE							= 1103;
			public const int UPDATE							= 1104;
			public const int DELETE							= 1105;
		}

		public static class AppNews
		{
			public const int VIEW_LIST						= 1201;
			public const int VIEW_DETAIL					= 1202;
			public const int CREATE							= 1203;
			public const int UPDATE							= 1204;
			public const int DELETE							= 1205;
			public const int PUBLIC							= 1206;
			public const int UNPUBLIC						= 1207;
		}

		public static class AppActor
        {
			public const int VIEW_LIST						= 1301;
			public const int VIEW_DETAIL					= 1302;
			public const int CREATE							= 1303;
			public const int UPDATE							= 1304;
			public const int DELETE							= 1305;
		}

        public static class AppMaker
        {
			public const int VIEW_LIST						= 1401;
			public const int VIEW_DETAIL					= 1402;
			public const int CREATE							= 1403;
			public const int UPDATE							= 1404;
			public const int DELETE							= 1405;
		}

        public static class AppStudio
        {
			public const int VIEW_LIST						= 1501;
			public const int VIEW_DETAIL					= 1502;
			public const int CREATE							= 1503;
			public const int UPDATE							= 1504;
			public const int DELETE							= 1505;
		}

        public static class AppGenres
        {
			public const int VIEW_LIST						= 1601;
			public const int VIEW_DETAIL					= 1602;
			public const int CREATE							= 1603;
			public const int UPDATE							= 1604;
			public const int DELETE							= 1605;
		}

        public static class AppFilm
        {
			public const int VIEW_LIST						= 1701;
			public const int VIEW_DETAIL					= 1702;
			public const int CREATE							= 1703;
			public const int UPDATE							= 1704;
			public const int DELETE							= 1705;
            public const int PUBLIC							= 1706;
            public const int UNPUBLIC						= 1707;
        }

        public static class AppStatus
        {
			public const int VIEW_LIST						= 1801;
			public const int VIEW_DETAIL					= 1802;
			public const int CREATE							= 1803;
			public const int UPDATE							= 1804;
			public const int DELETE							= 1805;
		}

        public static class AppEpisode
        {
			public const int VIEW_LIST						= 1901;
			public const int VIEW_DETAIL					= 1902;
			public const int CREATE							= 1903;
			public const int UPDATE							= 1904;
			public const int DELETE							= 1905;
		}

        public static class AppComment
        {
			public const int VIEW_LIST						= 2001;
			public const int CREATE							= 2003;
			public const int VIEW_DETAIL					= 2002;
			public const int UPDATE							= 2004;
			public const int DELETE							= 2005;
		}
    }
}
