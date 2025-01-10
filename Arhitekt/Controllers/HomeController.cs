using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arhitekt.Models;
using Arhitekt.Data;
using System.Linq;

namespace Arhitekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArhitektContext _context;

        public HomeController(ArhitektContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch all projects from the database
            var projects = _context.Projects.ToList();

            // Pass the projects to the view using ViewData
            ViewData["Projects"] = projects;

            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Discover()
        {
            // Fetch all users with the Architect role
            var architects = _context.Users
                .Where(u => u.Role == UserRole.Architect)
                .ToList();

            return View(architects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
