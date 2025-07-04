using Microsoft.AspNetCore.Mvc;
using NaShop.Data;

namespace NaShop.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    ApplicationDbContext  _context= new ApplicationDbContext();

    public IActionResult Index()
    {
        ViewBag.categories = _context.Categories.ToList();
        ViewBag.products = _context.Products.ToList();
        return View();
    }
}