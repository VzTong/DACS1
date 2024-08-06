namespace MoviePJ.Areas.Admin.ViewModels.User
{
	public class BlockUserVM
	{
		public int Id { get; set; }
		public DateTime? BlockedTo { get; set; }
		public bool Permanentblock { get; set; }
	}
}
