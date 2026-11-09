using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Controllers;

public class SupplierController : Controller
{
    private readonly ApplicationDbContext _context;

    public SupplierController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var suppliers = _context.Suppliers.Include(x => x.Products).ToList();
        return View(suppliers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        if (!ModelState.IsValid)
        {
            return View(supplier);
        }

        _context.Suppliers.Add(supplier);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var supplier = _context.Suppliers.Find(id);
        if (supplier == null)
            return NotFound();

        return View(supplier);
    }

    [HttpPost]
    public IActionResult Edit(Supplier supplier)
    {
        if (!ModelState.IsValid)
        {
            return View(supplier);
        }

        _context.Suppliers.Update(supplier);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var supplier = _context.Suppliers.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        if (supplier == null)
            return NotFound();

        return View(supplier);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var supplier = _context.Suppliers.Find(id);
        if (supplier == null)
            return NotFound();

        _context.Suppliers.Remove(supplier);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
