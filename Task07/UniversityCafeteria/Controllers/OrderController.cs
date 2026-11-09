using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var orders = _context.Orders.Include(x => x.Employee).ToList();
        return View(orders);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Employees = new SelectList(_context.Employees.ToList(), "Id", "FullName");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (!_context.Employees.Any(x => x.Id == order.EmployeeId))
            ModelState.AddModelError("EmployeeId", "Choose an existing employee.");
        if (!ModelState.IsValid)
        {
            ViewBag.Employees = new SelectList(_context.Employees.ToList(), "Id", "FullName", order.EmployeeId);
            return View(order);
        }

        _context.Orders.Add(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();

        ViewBag.Employees = new SelectList(_context.Employees.ToList(), "Id", "FullName", order.EmployeeId);
        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        if (!_context.Employees.Any(x => x.Id == order.EmployeeId))
            ModelState.AddModelError("EmployeeId", "Choose an existing employee.");
        if (!ModelState.IsValid)
        {
            ViewBag.Employees = new SelectList(_context.Employees.ToList(), "Id", "FullName", order.EmployeeId);
            return View(order);
        }

        _context.Orders.Update(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var order = _context.Orders.Include(x => x.Employee).FirstOrDefault(x => x.Id == id);
        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
