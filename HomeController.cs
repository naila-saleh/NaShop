using Microsoft.AspNetCore.Mvc;

namespace NaShop;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}