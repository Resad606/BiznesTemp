using Business.Helpers;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business.Areas.manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AddDbContext _addDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamController(AddDbContext addDbContex,IWebHostEnvironment webHostEnvironment)
        {
            _addDbContext = addDbContex;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Team> teams = _addDbContext.Teams.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if(team.ImageFile!= null)
            {
                if(team.ImageFile.ContentType!="Image/png" && team.ImageFile.ContentType!= "Image/jpeg")
                {
                    ModelState.AddModelError("Image", "Wekil ancaq png ve jpeg ola biler");
                    return View();
                }
                if(team.ImageFile.Length > 34567)
                {
                    ModelState.AddModelError("Image", "wekil 3 mbdan cox ola bilmez ");
                }
               team.Imagge = FileManager.SaveFile(_webHostEnvironment.WebRootPath,"uploads/team",team.ImageFile);
                _addDbContext.Teams.Add(team);  
                
            }
            _addDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Upload(int id)
        {
            Team team = _addDbContext.Teams.Find(id);
            if(team!=null)
            {
                return NotFound();
            }
            return View();  
        }
        [HttpPost]
        public IActionResult Upload(Team team )
        {
            Team exsisit = _addDbContext.Teams.Find(team.Id);
            if (team!=null)
            {
                if(team.ImageFile==null)
                {
                    if (team.ImageFile.ContentType != "Image/png" && team.ImageFile.ContentType != "Image/jpeg")
                    {
                        ModelState.AddModelError("Image", "Wekil ancaq png ve jpeg ola biler");
                        return View();
                    }
                    if (team.ImageFile.Length > 345678)
                    {
                        ModelState.AddModelError("Image", "wekil 3 mb dan cox ola bilmez");
                        return View();
                    }
                }
                FileManager.DeleteFile(_webHostEnvironment.WebRootPath, "uploads/team", exsisit.Imagge);
                exsisit.Imagge = FileManager.SaveFile(_webHostEnvironment.WebRootPath, "uploads/team", team.ImageFile);
            }
            exsisit.Profession = team.Profession;
            exsisit.FullName = team.FullName;   
            _addDbContext.SaveChanges();
            return RedirectToAction("Index");



        }
        public IActionResult Delete(int id)
        {
            Team team = _addDbContext.Teams.Find(id);
            _addDbContext.Teams.Remove(team);
            _addDbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}
