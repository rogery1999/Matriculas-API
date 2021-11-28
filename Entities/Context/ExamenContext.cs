using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class ExamenContext : DbContext
    {
        public ExamenContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Alumno>? Alumnos { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<InscripcionCurso>? InscripcionesCursos { get; set; }
        public DbSet<Notas>? Notas { get; set; }
    }
}
