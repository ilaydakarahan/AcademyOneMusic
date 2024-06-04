using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
	public class _DefaultNewHitsComponent(ISongService _songService) : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var values = _songService.TGetSongWithAlbum().OrderByDescending(x=>x.SongId).Take(6).ToList();
			return View(values);
		}
	}
}
