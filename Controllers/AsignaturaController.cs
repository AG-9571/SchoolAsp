using System;
using Microsoft.AspNetCore.Mvc;
using school.Models;

namespace school.Controllers;

public class AsignaturaController : Controller
{
    private EscuelaContext _context;

    public IActionResult Index(){
        var m = new Asignatura{
            name =  "hola",
            id = Guid.NewGuid()
        };

        return View(_context.Asignaturas?.FirstOrDefault());
        //return View(m);
    }
    public AsignaturaController( EscuelaContext context)
    {
        _context = context;
    }
    public IActionResult Asignaturas(){
        var Asignatura = _context.Asignaturas?.ToList();
        return View(Asignatura);
    }
}