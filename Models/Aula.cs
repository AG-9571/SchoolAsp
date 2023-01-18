using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace school.Models;

public class Aula : objectBaseModel
{
    public Guid  AulaId {get; set;}
    public string? desctiption {get; set;}
    public TiposJornada Jornada { get; set; }
    public List<Asignatura>? Asignaturas{ get; set; }
    public List<Alumno>? Alumnos { get; set; }
    public ticher? ticher { get; set; }
    public string? and {get; set;}
    public string? end {get; set;}


    public string? Dirección { get; set; }

}

public enum TiposJornada
{
    Mañana, 
    Tarde, 
    Noche
}
