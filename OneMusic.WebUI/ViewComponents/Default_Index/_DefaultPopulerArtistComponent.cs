using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultPopulerArtistComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

		public _DefaultPopulerArtistComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var artists =  await _userManager.GetUsersInRoleAsync("Artist");
            var popartist = artists.OrderByDescending(x => x.Id).Take(7).ToList();

            return View(popartist);
        }
    }
}
