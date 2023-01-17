using System;
using System.ComponentModel.DataAnnotations;

namespace school.Models;

public class Evaluacion
{
    [Key]
    public  Guid Evaluacionid {get; set;}
    public Alumno? Alumno { get; set; }
    public Asignatura? Asignatura  { get; set; }

    public float Nota { get; set; }

    public override string ToString()
    {
        return $"{Nota}, {Alumno?.name}, {Asignatura?.id}";
    }
}
