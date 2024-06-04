using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
	public class _DefaultAlbumListComponent : ViewComponent
	{
		private readonly IAlbumService _albumService;

		public _DefaultAlbumListComponent(IAlbumService albumService)
		{
			_albumService = albumService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _albumService.TGetList();
			return View(values);
		}
	}
}
