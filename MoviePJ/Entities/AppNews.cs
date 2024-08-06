using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
	public class AppNews : AppEntityBase
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string? Summary { get; set; }
		public string? Content { get; set; }
		public long Views { get; set; }
		public float Votes { get; set; }
		public bool Published { get; set; }
		public DateTime? PublishedAt { get; set; }
		public string? Cover { get; set; }
		public string? CoverThumbnail { get; set; }
		public string? StampPath { get; set; }
		public int? UserId { get; set; }
		public AppUser Users { get; set; }
	}
}
