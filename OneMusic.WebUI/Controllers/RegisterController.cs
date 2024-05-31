using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Models;

namespace OneMusic.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            AppUser user=new AppUser
            {
                Email = model.Email,
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname
            };

            if (model.Password == model.ConfirmPassword)
            {    //Yukarıda usermanager içinde hangi sınıf yazılıysa(app user mı identity sınıfı mı ) o türden aşağıdaki asenkron metoda nesne veriyoruz.
            
                var result=await _userManager.CreateAsync(user , model.Password);    //2 parametre bekliyor, birincisi yukarıdan gelen user, diğerine password u vericez, o hashlicek.
                if(result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Visitor");     //Dışarıdan bir kullanıcı geldiğinde otomatik visitor rolü atanacak ona.
                                                                        //Sonrasında istenen rolü admin kendi tarafında verebilir.
                    return RedirectToAction("Index", "Login");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }


            return View();
  

        }

    }
}
