using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Models;

namespace Proyecto2025.BE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<AlumnoMateria> AlumnoMaterias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlumnoMateria>()
                .HasKey(am => new { am.AlumnoId, am.MateriaId });

            modelBuilder.Entity<AlumnoMateria>()
                .HasOne(am => am.Alumno)
                .WithMany(a => a.AlumnoMaterias)
                .HasForeignKey(am => am.AlumnoId);

            modelBuilder.Entity<AlumnoMateria>()
                .HasOne(am => am.Materia)
                .WithMany(m => m.AlumnoMaterias)
                .HasForeignKey(am => am.MateriaId);
        }
    }
}