using school.Models;
using Microsoft.EntityFrameworkCore;

public class EscuelaContext : DbContext
{
    public DbSet<School>? Schools {get; set;}
    public DbSet<Asignatura>? Asignaturas {get; set;}
    public DbSet<Curso>? Cursos {get; set;}
    public DbSet<Evaluacion>? Evaluacios {get; set;}

    public EscuelaContext (DbContextOptions<EscuelaContext> options): base(options)
    {

    }
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);

            var escuela = new School();
            escuela.AñoDeCreacion = 2005;
            escuela.Schoolid = Guid.NewGuid();
            escuela.name = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Direccion = "Avd Siempre viva";
            escuela.typeschool = typeschool.Primaria;

            modelBuilder.Entity<School>().HasData(escuela);
            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura{
                    id = Guid.NewGuid(),
                    name = "español",
                },
                new Asignatura{
                    id = Guid.NewGuid(),
                    name = "español",
                }
            );
            modelBuilder.Entity<Alumno>().HasData( generatAulumnos( 22 ).ToArray());

    }
    private List<Alumno> generatAulumnos ( int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var listaAlumnos = from n1 in nombre1
                           from n2 in nombre2
                           from a1 in apellido1
                            select new Alumno { 
                                name = $"{n1} {n2} {a1}" ,
                                id = Guid.NewGuid()
                                };

        return listaAlumnos.OrderBy((al) => al.id).Take(cantidad).ToList();
    }

}