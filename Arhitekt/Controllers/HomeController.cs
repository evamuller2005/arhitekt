using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arhitekt.Models;
using Arhitekt.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arhitekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArhitektContext _context;

        public HomeController(ArhitektContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult SearchResults(string? query, string? searchType)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new SearchResultsViewModel());
        }

        var users = new List<User>();
        var projects = new List<Project>();

        if (searchType == "All" || searchType == "Users")
        {
            users = _context.Users
                .Where(u => EF.Functions.Like(u.FirstName, $"%{query}%")
                    || EF.Functions.Like(u.LastName, $"%{query}%")
                    || EF.Functions.Like(u.Email, $"%{query}%"))
                .ToList();
        }

        if (searchType == "All" || searchType == "Projects")
        {
            projects = _context.Projects
                .Where(p => EF.Functions.Like(p.Name, $"%{query}%")
                    || EF.Functions.Like(p.Description, $"%{query}%"))
                .ToList();
        }

        var model = new SearchResultsViewModel
        {
            Users = users,
            Projects = projects
        };

        return View(model);
    }

        public IActionResult Index()
        {
            // Fetch all projects from the database
            var projects = _context.Projects.ToList();

            // Pass the projects to the view using ViewData
            ViewData["Projects"] = projects;

            return View();
        }

        [Authorize]
        public IActionResult Messages()
        {
            return View();
        }

        [Authorize]
        public IActionResult Projects()
        {
            return View();
        }

        [Authorize]
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Register()
        {
            return Redirect("~/Identity/Account/Register");
        }

        [Authorize]
        public IActionResult Discover()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
