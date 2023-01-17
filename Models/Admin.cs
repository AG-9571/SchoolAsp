using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school.Models;

public class Admin : objectBaseModel
{
    public string? idSchool {get; set;}
    [Required]
    public string? pass {get; set;}
    [Required]
    public string? email {get; set;}
    public int code {get; set;}

}

