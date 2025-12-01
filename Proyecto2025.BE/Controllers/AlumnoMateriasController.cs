// Backend/Controllers/AlumnoMateriasController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Data;
using Proyecto2025.BE.Models;

namespace Proyecto2025.BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoMateriasController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AlumnoMateriasController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/alumnomaterias/by-alumno/5
        [HttpGet("by-alumno/{alumnoId:int}")]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateriasByAlumno(int alumnoId)
        {
            var materias = await _db.AlumnoMaterias
                .Where(am => am.AlumnoId == alumnoId)
                .Select(am => am.Materia!)
                .AsNoTracking()
                .ToListAsync();

            return Ok(materias);
        }

        // POST: api/alumnomaterias
        // Body: { "alumnoId": 1, "materiaId": 2 }
        [HttpPost]
        public async Task<IActionResult> Vincular([FromBody] AlumnoMateria vinculo)
        {
            var existe = await _db.AlumnoMaterias.AnyAsync(am =>
                am.AlumnoId == vinculo.AlumnoId && am.MateriaId == vinculo.MateriaId);
            if (existe) return Conflict("El alumno ya está vinculado a esa materia.");

            _db.AlumnoMaterias.Add(vinculo);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/alumnomaterias/1/2
        [HttpDelete("{alumnoId:int}/{materiaId:int}")]
        public async Task<IActionResult> Desvincular(int alumnoId, int materiaId)
        {
            var vinculo = await _db.AlumnoMaterias.FindAsync(alumnoId, materiaId);
            if (vinculo == null) return NotFound();

            _db.AlumnoMaterias.Remove(vinculo);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}