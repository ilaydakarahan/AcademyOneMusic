﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ArtistsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()    //Sanatçılar sayfasında rolü artist seçili olanları(yani sanatçıların zaten seçilidir.) listeler.
        {
            var values = await _userManager.GetUsersInRoleAsync("Artist");

            return View(values);
        }
    }
}
