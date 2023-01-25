
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Business.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }

    }
}