// Backend/Models/AlumnoMateria.cs
namespace Proyecto2025.BE.Models
{
    // Entidad intermedia para la relación muchos-a-muchos entre Alumno y Materia
    public class AlumnoMateria
    {
        // Claves foráneas (juntas forman la clave compuesta)
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }

        // Navegación hacia Alumno y Materia
        public Alumno? Alumno { get; set; }
        public Materia? Materia { get; set; }
    }
}