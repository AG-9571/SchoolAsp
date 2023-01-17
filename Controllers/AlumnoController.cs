using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using school.Models;

namespace school.Controllers;

public class AlumnoController : Controller
{
    private readonly ILogger<AlumnoController> ?_logger;

    public IActionResult Index()
    {
        var Asignatura = new Alumno(){    
            id = Guid.NewGuid(),
            name = "pepe perez"
                
        };

        return View(Asignatura);
    }
    public IActionResult Alumnos()
    {
        var Alumnos = GenerarAlumnosAlAzar(20);

        return View(Alumnos);
    }
     private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var listaAlumnos = from n1 in nombre1
                            from n2 in nombre2
                            from a1 in apellido1
                            select new Alumno { 
                                name = $"{n1} {n2} {a1}" ,
                                id = Guid.NewGuid()
                                };

        return listaAlumnos.OrderBy((al) => al.id).Take(cantidad).ToList();
    }

}