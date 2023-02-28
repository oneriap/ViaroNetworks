using Microsoft.EntityFrameworkCore;
using ViaroTest.Models;

namespace ViaroTest.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Alumno> Alumnos { get; set;}

        public DbSet<Genero> Generos { get; set;}

        public DbSet<Profesor> Profesors { get; set;}

        public DbSet<Grado> Grados { get; set; }

        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }
    }
}