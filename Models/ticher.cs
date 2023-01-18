using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace school.Models;
public class ticher: objectBaseModel
{
    public string? email { get; set; }
    public string? pass { get; set; }
    public Permices Permices {get; set;}
    public List<Aula>? idCurso {get; set;}
    public List<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();
}