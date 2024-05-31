using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Models;

namespace OneMusic.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values=_userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user=_userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;

            var roles=_roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user); //Kullanıcıya göre rolleri listele

            List<RoleAssignViewModel> roleAssignList=new List<RoleAssignViewModel>();   //seçilen kişinin rollerini listeler yalnızca.

            foreach (var item in roles)
            {
                var model = new RoleAssignViewModel();
                model.RoleId= item.Id;
                model.RoleName = item.Name;
                model.RoleExist=userRoles.Contains(item.Name);  //checkbox gibi. Kişinin sahip olduğu roller tikli gelir bu sayede.

                roleAssignList.Add(model);  //aldığı değerlerin hepsini roleassignlist' e atar.
            }

            return View(roleAssignList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            int userid = (int)TempData["userid"];

            var user= _userManager.Users.FirstOrDefault(x=>x.Id==userid);

            foreach (var item in model)
            {
                if(item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }

            }

            return RedirectToAction("Index");
        }
    }
}
