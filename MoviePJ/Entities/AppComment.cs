using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppComment : AppEntityBase
	{
        public AppComment()
        {
            AppCommentDetails = new HashSet<AppCommentDetail>();
        }
        public string Comment {  get; set; }
        public int FilmId { get; set; }
        public AppFilm AppFilm { get; set; }
		public ICollection<AppCommentDetail> AppCommentDetails { get; set; }

	}
}
