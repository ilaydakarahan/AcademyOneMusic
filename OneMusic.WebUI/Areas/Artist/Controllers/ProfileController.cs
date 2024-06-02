using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Areas.Artist.Models;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new ArtistEditViewModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Surname = user.Surname,
                ImageUrl = user.ImageUrl,
                UserName = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ArtistEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (model.ImageFile != null)     //dosyadan seçilen resmi guid değer atayarak proje içerisindeki klasöre kopyalayacak.
            {
                var resource = Directory.GetCurrentDirectory();     //Projenin bilgisayarda var olduğu klasörün adresini alıyor.
                var extension = Path.GetExtension(model.ImageFile.FileName);    //Bu da dosya uzantısını alır.(jpg,png vs.)
                var imageName = Guid.NewGuid() + extension;                     //Yeni guid değer oluşturup sonuna yukarıdan aldığımız uzantıyı ekliyoruz.
                var saveLocation = resource + "/wwwroot/images/" + imageName;   //Kaydedeceğimiz yer projenin olduğu dizine git ordan da yazdığımız images dosyasına git,dosyanın ismini yaz.
                var stream = new FileStream(saveLocation, FileMode.Create);     //Kaydettik.
                await model.ImageFile.CopyToAsync(stream);

                user.ImageUrl = "/images/" + imageName;     //Veritabanına dosyanın yolunu atadık.
            }

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (result == true)
            {
                if (model.NewPassword != null && model.ConfirmPassword == model.NewPassword)
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (!changePasswordResult.Succeeded)
                    {
                        foreach (var item in changePasswordResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                            return View();
                        }
                    }
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            ModelState.AddModelError("", "Mevcut Şifreniz Hatalı");
            return View();

        }

    }
}
