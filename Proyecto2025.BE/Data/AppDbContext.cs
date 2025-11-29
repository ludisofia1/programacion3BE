using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Models;


namespace Proyecto2025.BE.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
