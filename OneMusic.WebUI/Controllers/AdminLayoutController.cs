﻿using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
