// Backend/Models/Materia.cs
namespace Proyecto2025.BE.Models
{
    // Entidad simple para Materias
    public class Materia
    {
        // Clave primaria
        public int MateriaId { get; set; }

        // Nombre de la materia
        public string Nombre { get; set; } = string.Empty;

        // (Opcional) Código único de la materia
        public string Codigo { get; set; } = string.Empty;

        // Relación con la entidad intermedia AlumnoMateria (1 Materia -> muchos vínculos)
        public ICollection<AlumnoMateria>? AlumnoMaterias { get; set; }
    }
}
