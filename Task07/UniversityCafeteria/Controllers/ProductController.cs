using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
        ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!_context.Categories.Any(x => x.Id == product.CategoryId))
            ModelState.AddModelError("CategoryId", "Choose an existing category.");
        if (!_context.Suppliers.Any(x => x.Id == product.SupplierId))
            ModelState.AddModelError("SupplierId", "Choose an existing supplier.");
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", product.CategoryId);
            ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
            return View(product);
        }

        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return NotFound();

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", product.CategoryId);
        ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (!_context.Categories.Any(x => x.Id == product.CategoryId))
            ModelState.AddModelError("CategoryId", "Choose an existing category.");
        if (!_context.Suppliers.Any(x => x.Id == product.SupplierId))
            ModelState.AddModelError("SupplierId", "Choose an existing supplier.");
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", product.CategoryId);
            ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
            return View(product);
        }

        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var product = _context.Products.Include(x => x.Category).Include(x => x.Supplier).FirstOrDefault(x => x.Id == id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
