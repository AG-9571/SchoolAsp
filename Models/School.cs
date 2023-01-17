using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school.Models;
public class School
{
    [Key]
    public Guid Schoolid { get; set; }
    public int AñoDeCreacion { get; set; }
    public string name { get; set; }

    public string Pais { get; set; }
    public string Ciudad { get; set; }

    public string? Direccion { get; set; }

    public typeschool typeschool { get; set; }
    public List<Curso> Cursos { get; set; }

    public School(
        string name, 
        int año,
        typeschool typeschool,
        string pais = "", string ciudad = "") : base()
    {
        (name, AñoDeCreacion) = (name, año);
        Pais = pais;
        Ciudad = ciudad;
    }
    public School()
    {

    }

    public override string ToString()
    {
        return $"Nombre: \"{name}\", Tipo: {typeschool} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
    }
}

public enum typeschool
{
    PreEscolar,
    Primaria, 
    Secundaria, 
    Preparatoria,
    Universidad
}

