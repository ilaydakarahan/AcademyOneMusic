using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultTopAlbumComponent : ViewComponent
    {
        private readonly IAlbumService _albumService;

        public _DefaultTopAlbumComponent(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _albumService.TGetList().OrderByDescending(x=>x.AlbumId).Take(6).ToList();
            return View(values);
        }

    }
}
