using System;

namespace school.Models;

public class Evaluaciones : objectBaseModel
{
    public Alumno? Alumno { get; set; }
    public Asignatura? Asignatura  { get; set; }
    public string? promedio {get; set;}
    public string? Nota { get; set; }

    public Evaluaciones() => Id = Guid.NewGuid();
}
