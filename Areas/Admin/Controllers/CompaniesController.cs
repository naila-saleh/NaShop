using Microsoft.AspNetCore.Mvc;
using NaShop.Data;
using NaShop.Models;

namespace NaShop.Areas.Admin.Controllers;

[Area("Admin")]
public class CompaniesController : Controller
{
    private ApplicationDbContext _context = new ApplicationDbContext();
    [HttpGet]
    public IActionResult Index()
    {
        var companies = _context.Companies.ToList();
        return View(companies);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Company());
    }

    [HttpPost]
    public IActionResult Create(Company company)
    {
        if (ModelState.IsValid)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            TempData["success"] = "Company Created Successfully";
            return RedirectToAction("Index");
        }
        return View(company);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var company = _context.Companies.Find(id);
        return View(company);
    }

    [HttpPost]
    public IActionResult Edit(Company company)
    {
        if (!ModelState.IsValid)return View(company);
        _context.Companies.Update(company);
        _context.SaveChanges();
        TempData["success"] = "Company Edited Successfully";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var company = _context.Companies.Find(id);
        return View(company);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var company = _context.Companies.Find(id);
        if (company != null)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
        return View(company);
    }
}