using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XssTestMvc.Models;

namespace XssTestMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public ContentResult SearchAPI(string searchTerm)
    {
        var results = new List<string>() {
            searchTerm + " 1",
            searchTerm + " 2",
            searchTerm + " 3"
        };
        return new ContentResult
        {
            ContentType = "text/html",
            Content = $"[\"{string.Join("\", \"", results)}\"]"
        };
    }
}
