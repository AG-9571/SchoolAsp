using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school.Models;

public class Asignatura : objectBaseModel
{
    public Aula? Aula {set; get;}
    public long hora {get; set;}
    public Wekend Wekend {get; set;}    
}
public enum Wekend
{
    lunes,
    martes,
    miercoles,
    jueves,
    viernes,
    Sabado
}
public enum asignatura 
{
    prescolar,
    matematicas, 
    programacion,
    
}
