using System.Collections.Generic;

namespace MoviePJ.Components.CateMenu
{
	public class CateMenuViewModel
	{
		public CateMenuViewModel()
		{
			Childs = new HashSet<CateMenuViewModel>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public ICollection<CateMenuViewModel> Childs { get; set; }
	}
}
