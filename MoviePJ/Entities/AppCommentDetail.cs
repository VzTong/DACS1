using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
    public class AppCommentDetail : AppEntityBase
    {
        public int UserId {  get; set; }
        public int? CommentId {  get; set; }
        public AppUser AppUser { get; set; }
        public AppComment AppComment { get; set; }
    }
}
