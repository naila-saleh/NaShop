using Microsoft.AspNetCore.Mvc;
using NaShop.Data;
using NaShop.Models;

namespace NaShop.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    ApplicationDbContext _context=new ApplicationDbContext();
    [HttpGet]
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            //Response.Cookies.Append("success","Category Created Successfully");
            return RedirectToAction("Index");
        }
        return View(category);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var category = _context.Categories.Find(id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid)return View(category);
        _context.Categories.Update(category);
        _context.SaveChanges();
        TempData["success"] = "Category Edited Successfully";
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}