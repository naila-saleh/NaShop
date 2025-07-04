using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaShop.Data;
using NaShop.Models;
using NaShop.Services;

namespace NaShop.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    ApplicationDbContext _context=new ApplicationDbContext();
    [HttpGet]
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Companies = _context.Companies.ToList();
        return View(new Product());
    }

    [HttpPost]
    public IActionResult Create(Product product,IFormFile Image)
    {
        //ModelState.Remove("Category");
        if (Image != null && Image.Length > 0)
        {
            var imageService = new ImageService();
            string fileName = imageService.UploadImage(Image);
            product.Image = fileName;
            if (!ModelState.IsValid) return View(product);
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["success"] = "Product Created Successfully";
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Companies = _context.Companies.ToList();
        var product = _context.Products.Find(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product, IFormFile? Image)
    {
        product.Image = _context.Products.AsNoTracking().FirstOrDefault(p=>p.Id==product.Id).Image;
        if (Image != null && Image.Length > 0)
        {
            var imageService = new ImageService();
            if(product.Image!=null) imageService.DeleteImage(product.Image);
            string fileName = imageService.UploadImage(Image);
            product.Image = fileName;
        }
        if (!ModelState.IsValid) return View(product);
        _context.Products.Update(product);
        _context.SaveChanges();
        TempData["success"] = "Product Edited Successfully";
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        var imageService = new ImageService();
        imageService.DeleteImage(product.Image);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}