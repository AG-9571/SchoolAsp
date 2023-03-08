using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace school.Models;
public class Alumno: objectBaseModel
{
    public string? subname {get; set;}
    public string? email { get; set; }
    public string? pass { get; set; }
    public long? phone {get; set;}
    public Aula? idCurso {get; set;}
    public School? schoolId {get; set;}
    public Permices Permices {get; set;}
    public List<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();
}
