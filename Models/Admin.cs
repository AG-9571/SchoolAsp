using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school.Models;

public class Admin : objectBaseModel
{
    public School? SchoolId {get; set;}
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    [StringLength(250)]
    public string? pass {get; set;}
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    [StringLength(250)]
    public string? email {get; set;}
    public Permices Permices {get; set;}

    [StringLength(25)]
    public int code {get; set;}

}
public enum Permices 
{
    ticher,
    Alumno,
    oficine,
    director,
    admin
}

