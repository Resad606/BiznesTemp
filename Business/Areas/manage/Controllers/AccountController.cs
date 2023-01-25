using Business.Areas.manage.ViewModels;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business.Areas.manage.Controllers
{
    [Area("Manage")]
    [Authorize("SuperAdmin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await userManager.FindByNameAsync(adminLoginViewModel.UserName); 
            if (user == null)
            {
                ModelState.AddModelError("", "Username  or password is incorrect");
            }
            var result = await  signInManager.PasswordSignInAsync(user, adminLoginViewModel.Password,false,false);
            if (result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or passw2ord is incorrect");
            }
            return RedirectToAction("Index", "DashBoard");   
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
