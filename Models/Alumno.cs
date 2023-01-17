using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace school.Models;
public class Alumno
{
    [Key]
    public Guid id {get; set;}
    public string? name { get; set;}
    public string? nameAlumno {get; set;}
    public string? email { get; set; }
    private string? pass { get; set; }
    
    public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
}
