using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppGenres : AppEntityBase
	{
        public AppGenres()
        {
            ChildCategories = new HashSet<AppGenres>();
            AppGenresFilms = new HashSet<AppGenresFilm>();
        }
        public string Name { get; set; }
		public string? Desc { get; set; }
		public string? Slug { get; set; }
        public int CateLevel { get; set; }
        public bool HasChild { get; set; }
        public int? ParentCateId { get; set; }
        public AppGenres ParentCategory { get; set; }
        public ICollection<AppGenres> ChildCategories { get; set; }
        public ICollection<AppGenresFilm> AppGenresFilms { get; set; }
	}
}
