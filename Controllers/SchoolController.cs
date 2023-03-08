using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.Models;

namespace school.Controllers;

public class SchoolController : Controller
{
    private EscuelaContext _context;
    private readonly ILogger<SchoolController>? _logger;

    public async Task<IActionResult> Index()
    {
        _context.Database.EnsureCreated();   
        return _context.Schools != null ? 
            View( await _context.Schools.ToListAsync()) :
            Problem("Entity set 'EscuelaContext.Alumnos'  is null.");
    }
    public SchoolController( EscuelaContext context)
    {
        _context = context;
    }
}