using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext context)
        {
            _db=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Message()
        {
            var messages = _db.ContactUs.ToList();
            return View(messages);
        }
        public async Task<IActionResult> About()
        {
            var aboutdata =await _db.About.ToListAsync();
            if (aboutdata == null)
            {
                return NotFound();
            }

            //ViewBag.Cat = category.Name;
           
            return View(aboutdata);
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> Fact()
        {
            var result = await _db.Facts.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            //ViewBag.Cat = category.Name;

            return View(result);
        }
        public async Task<IActionResult> Skill()
        {
            var result = await _db.Skills.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            //ViewBag.Cat = category.Name;

            return View(result);
        }
        public async Task<IActionResult> resume()
        {
            var result = await _db.Resumes.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            //ViewBag.Cat = category.Name;

            return View(result);
        }
        public async Task<IActionResult> services()
        {
            var result = await _db.Services.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            //ViewBag.Cat = category.Name;

            return View(result);
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                _db.ContactUs.Add(model);
                _db.SaveChanges();
               
                
            }
            return View("Message", model);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
