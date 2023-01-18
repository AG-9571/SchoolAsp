using System;

namespace school.Models;

public class Evaluaciones : objectBaseModel
{
    public Alumno? Alumno { get; set; }
    public Asignatura? Asignatura  { get; set; }
    public int promedio {get; set;}
    public float Nota { get; set; }

    public Evaluaciones() => Id = Guid.NewGuid();
}
