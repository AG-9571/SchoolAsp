using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using school.Models;

namespace school.Controllers;

public class SchoolController : Controller
{
    private EscuelaContext _context;
    private readonly ILogger<SchoolController>? _logger;

    public IActionResult Index()
    {
        _context.Database.EnsureCreated();
        var school = _context.Schools?.FirstOrDefault();
        
        return View(school);
    }
    public SchoolController( EscuelaContext context)
    {
        _context = context;
    }
}