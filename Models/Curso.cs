using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace school.Models;

public class Curso
{
    [Key]
    public Guid  CursoId {get; set;}
    public TiposJornada Jornada { get; set; }
    public List<Asignatura>? Asignaturas{ get; set; }
    public List<Alumno>? Alumnos{ get; set; }

    public string? Dirección { get; set; }

}

public enum TiposJornada
{
    Mañana, 
    Tarde, 
    Noche
}
