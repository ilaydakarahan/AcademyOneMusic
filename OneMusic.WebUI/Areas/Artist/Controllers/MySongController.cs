using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Areas.Artist.Models;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MySongController : Controller
    {
        private readonly ISongService _songService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAlbumService _albumService;

        public MySongController(ISongService songService, UserManager<AppUser> userManager, IAlbumService albumService)
        {
            _songService = songService;
            _userManager = userManager;
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);  //İlk login işlemi yaparken kullanıcı adıyla giriş yaptığımız için 
            var values = _songService.TGetSongswithAlbumByUserId(user.Id);      //findbyname metodunu kullanıyoruz.
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSong()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var albumList = _albumService.TGetAlbumsByArtist(user.Id);

            List<SelectListItem> albums = (from x in albumList
                                           select new SelectListItem
                                           {
                                               Text = x.AlbumName,
                                               Value = x.AlbumId.ToString()
                                           }).ToList();

            ViewBag.albums = albums;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSong(SongViewModel model)
        {
            var song = new Song
            {
                SongName = model.SongName,
                AlbumId = model.AlbumId
            };

            if(model.SongFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.SongFile.FileName).ToLower();
                if(extension != ".mp3")
                {
                    ModelState.AddModelError("SongFile", "Sadece mp3 dosyaları kabul edilir.");
                    return View(model);
                }
                var songName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/songs/" + songName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.SongFile.CopyToAsync(stream);
                song.SongUrl = "/songs/" + songName;            
            }

            _songService.TCreate(song);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSong(int id)
        {
            _songService.TDelete(id);
            return RedirectToAction("Index");
        }

    }
}
