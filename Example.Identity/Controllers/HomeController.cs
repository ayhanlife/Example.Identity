using Example.Identity.Entities;
using Example.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> appUser;
        private readonly SignInManager<AppUser> singInManager;
        private readonly RoleManager<AppRole> roleManager;
        public HomeController(UserManager<AppUser> appUser, SignInManager<AppUser> singInManager, RoleManager<AppRole> roleManager)
        {
            this.appUser = appUser;
            this.singInManager = singInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View(new UserCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.UserName,
                    PasswordHash = model.Password
                };

               


                var indetityResult = await appUser.CreateAsync(user, model.Password);
                if (indetityResult.Succeeded)
                {

                    await roleManager.CreateAsync(new()
                    {
                        Name = "Admin",
                        CretedTime = DateTime.Now,
                    });

                    await appUser.AddToRoleAsync(user, "Admin");// Rol ata

                    return RedirectToAction("Index");
                }
                foreach (var error in indetityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }


        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(UserSingInModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await singInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (signInResult.Succeeded)// BAŞARILI
                {
                    var user = await appUser.FindByNameAsync(model.UserName);
                    var roles = await appUser.GetRolesAsync(user);
                    if (roles.Contains)
                    {

                    }

                    Response.Redirect("/");

                }
                if (signInResult.IsLockedOut) // HESAP KİLİTLİ
                {

                }
                if (signInResult.IsNotAllowed) // tel veya mail Onaylanmamiş hesap
                {

                }

            }
            return View();
        }
        [Authorize]
        public IActionResult AutKontrol()
        {
            return View();
        }

    }
}
