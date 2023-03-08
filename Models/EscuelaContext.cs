using school.Models;
using Microsoft.EntityFrameworkCore;

public class EscuelaContext : DbContext
{
    //public DbSet<School>? Schools {get; set;}
    public DbSet<Asignatura>? Asignaturas {get; set;}
    public DbSet<Aula>? Aulas {get; set;}
    public DbSet<Evaluaciones>? Evaluaciones {get; set;}
    public DbSet<Alumno>? Alumnos {get; set;}
    public DbSet<Admin>? Admins {get; set;}
    public DbSet<ticher>? tichers {get; set;}
    public DbSet<School>? Schools {get; set;}

    public EscuelaContext (DbContextOptions<EscuelaContext> options): base(options)
    {

    }
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);

            var admin1 = new Admin 
            {
                Id = Guid.NewGuid(),
                name = "admin", 
                email = "admin@gmail.com",
                Permices = Permices.admin,
                pass = "admin123",
                code = 5548629010
            };
            modelBuilder.Entity<School>().HasData(GenerateSchool(22));
            modelBuilder.Entity<Alumno>().HasData( generatAulumnos( 22 ).ToArray());
            modelBuilder.Entity<Aula>().HasData( GenerateAula(22).ToArray() );
            modelBuilder.Entity<ticher>().HasData( GenerateTicher(22).ToArray() );
            modelBuilder.Entity<Asignatura>().HasData( GenerateAsing(10).ToArray() );
            modelBuilder.Entity<Admin>().HasData( GenerateAdmin(10).ToArray() );
            modelBuilder.Entity<Admin>().HasData( admin1 );
            modelBuilder.Entity<Evaluaciones>().HasData( GenerateEvaluation(10).ToArray() );

    }
    private List<School> GenerateSchool (int cantidad)
    {
        string[] name = {"benito juares", "tec de leon", "utl", "jorge", "Maria"};
        string[] tpsschool = {"Escuela primaria", "Escuela secundaria", "Preparatoria", "universidad"};
        string[] pais = {"Mexico", "Canada", "Estados Unidos", "Argentina"};
        string[] cuidad = {"Leon", "baltimore", "marta", "cascada"};
        var listaadmin =   from n1 in name
                           from tps in tpsschool
                           from ps in pais
                           from ct in cuidad
                            select new School
                            { 
                                Schoolid = Guid.NewGuid(),
                                name = $"{tps}{n1}",
                                Pais = $"{ps}",
                                Ciudad = $"{ct}"
                            };
        return listaadmin.OrderBy( item => item.Schoolid).Take( cantidad ).ToList(); 
    }
    private List<Evaluaciones> GenerateEvaluation ( int cantidad)
    {
        string[] name = { "periodo uno", "periodo dos","periodo tres" };
        string[] promedio = { "6.4", "7.2", "9", "8", "5", "8.5", "8.4" };
        string[] note = {"buen trabajo", "Mejora en tu redaccion", "Entrega todos los trabajos"};

        var listaadmin =   from n1 in name
                           from pm in promedio
                           from nt in note
                            select new Evaluaciones
                            { 
                                Id = Guid.NewGuid(),
                                name = $"{n1}",
                                promedio = $"{pm}",
                                Nota = $"{nt}"
                            };
        return listaadmin.OrderBy( item => item.Id).Take( cantidad ).ToList();
    }
    private List<Admin> GenerateAdmin ( int cantidad )
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" }; 

        var listaadmin =   from n1 in nombre1
                           from n2 in nombre2
                           from ap in apellido1
                            select new Admin 
                            { 
                                Id = Guid.NewGuid(),
                                name = $"{n1}{n2}{ap}",
                                email = $"{n1}{ap}@gmail.com" ,
                                Permices = Permices.admin,
                                pass =  "admin123",
                                code =  5548629010
                            };
        return listaadmin.OrderBy( item => item.Id).Take( cantidad ).ToList();
    }
    private List<Asignatura> GenerateAsing ( int cantidad)
    {
        string[] name = {"Matematicas", "Ciencias Sociales", "Quimica", "Progrmacion", "Español", "Idiomas Extrangeros" };
        long[]   hora = {7, 10, 11, 12, 1, 2, 5, 8 };
        Wekend[] weken = { Wekend.jueves, Wekend.lunes, Wekend.martes, Wekend.miercoles, Wekend.viernes, Wekend.Sabado};

        var listaAulas =   from n1 in name
                           from Hr in hora
                           from Wk in weken
                            select new Asignatura 
                            { 
                                Id = Guid.NewGuid(),
                                name = $"{n1}",
                                hora = Hr,
                                Wekend = Wk
                            };
        return listaAulas.OrderBy( item => item.Id).Take( cantidad ).ToList();
    }
    private List<ticher> GenerateTicher ( int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" }; 

        var listaAulas =   from n1 in nombre1
                           from n2 in nombre1
                           from ap in apellido1
                            select new ticher 
                            { 
                                Id = Guid.NewGuid(),
                                name = $"{n1} {n2} {ap}",
                                email = $"{n1}{ap}@gmail.com",
                                Permices = Permices.ticher
                            };
        return listaAulas.OrderBy( item => item.Id).Take( cantidad ).ToList();
    }
    private List<Aula> GenerateAula ( int cantidad )
    {
        string[] nombre1 = { "6-A", "1-B", "3-C", "2-C", "3-D", "5-A", "4-D" };
        TiposJornada[] jornadas = {TiposJornada.Mañana, TiposJornada.Tarde, TiposJornada.Noche};

        long[] numbers = { 4773998569, 4615329152, 5531678223, 4613561056 }; 

        var listaAulas = from n1 in nombre1
                           from n2 in nombre1
                           from jr in jornadas
                           from ph in numbers
                            select new Aula 
                            { 
                                AulaId = Guid.NewGuid(),
                                name = n1,
                                Jornada = jr

                            };
        return listaAulas.OrderBy( (item) => item.AulaId).Take( cantidad ).ToList();
    }
    private List<Alumno> generatAulumnos ( int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" }; 

        long[] numbers = { 4773998569, 4615329152, 5531678223 }; 

        var listaAlumnos = from n1 in nombre1
                           from n2 in nombre2
                           from ph in numbers
                           from a1 in apellido1
                            select new Alumno { 
                                name = $"{n1} {n2}" ,
                                subname = $"{a1}",
                                email = $"{n1} {n2} @gmail.com",
                                phone = ph,
                                Permices = Permices.Alumno,
                                Id = Guid.NewGuid()
                                };

        return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
    }
}