using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.AsNoTracking()
            .Include(p => p.Category).Include(p => p.Supplier)
            .OrderBy(p => p.Name).ToListAsync();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price,Quantity,CategoryId,SupplierId")] Product model)
    {
        if (!await _context.Categories.AnyAsync(c => c.Id == model.CategoryId))
            ModelState.AddModelError(nameof(Product.CategoryId), "Select an existing category.");
        if (!await _context.Suppliers.AnyAsync(s => s.Id == model.SupplierId))
            ModelState.AddModelError(nameof(Product.SupplierId), "Select an existing supplier.");

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model.CategoryId, model.SupplierId);
            return View(model);
        }

        _context.Products.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDropdowns(int? categoryId = null, int? supplierId = null)
    {
        ViewBag.Categories = new SelectList(await _context.Categories.AsNoTracking()
            .OrderBy(c => c.Name).ToListAsync(), "Id", "Name", categoryId);
        ViewBag.Suppliers = new SelectList(await _context.Suppliers.AsNoTracking()
            .OrderBy(s => s.Name).ToListAsync(), "Id", "Name", supplierId);
    }
}
