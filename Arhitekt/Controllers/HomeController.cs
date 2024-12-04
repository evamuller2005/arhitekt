using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arhitekt.Models;
using Arhitekt.Data;


namespace Arhitekt.Controllers;

public class HomeController : Controller
{
    private readonly ArhitektContext _context;
    public HomeController(ArhitektContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
