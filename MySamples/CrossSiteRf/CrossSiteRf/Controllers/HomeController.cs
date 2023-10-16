using System.Diagnostics;
using CrossSiteRf.Helpers;
using Microsoft.AspNetCore.Mvc;
using CrossSiteRf.Models;

namespace CrossSiteRf.Controllers;

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
    
    public IActionResult AddToCart()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddToCart(ShoppingCartItem item)
    {
        ShoppingCartHelper.addToCart(item);
        return RedirectToAction("ShowCart");
    }

    // http://localhost:5207/Home/ShowCart
    public IActionResult ShowCart()
    {
        var cart = ShoppingCartHelper.getCart();
        return View(cart);
    }
}