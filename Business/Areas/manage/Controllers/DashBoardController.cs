using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business.Areas.manage.Controllers
{
    [Area("Manage")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AddDbContext> _userManager;

        public DashBoardController(UserManager<AddDbContext> userManager) {
           _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        FullName = "Resad Isayev",
        //        UserName = "SuperAdmin"
        //    };
           
        //    var result = await _userManager.CreateAsync(user,"sezsedzsed");
        //    return Ok(result);
        //}
    }
}
