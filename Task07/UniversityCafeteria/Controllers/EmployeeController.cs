using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.Include(x => x.Orders).ToList();
        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        _context.Employees.Add(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
            return NotFound();

        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        _context.Employees.Update(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var employee = _context.Employees.Include(x => x.Orders).FirstOrDefault(x => x.Id == id);
        if (employee == null)
            return NotFound();

        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
            return NotFound();

        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
