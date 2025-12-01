// Backend/Controllers/MateriasController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BE.Data;
using Proyecto2025.BE.Models;

namespace Proyecto2025.BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MateriasController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetAll()
        {
            var list = await _db.Materias.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // GET: api/materias/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Materia>> GetById(int id)
        {
            var materia = await _db.Materias.FindAsync(id);
            if (materia == null) return NotFound();
            return Ok(materia);
        }

        // POST: api/materias
        [HttpPost]
        public async Task<ActionResult<Materia>> Create([FromBody] Materia materia)
        {
            _db.Materias.Add(materia);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = materia.MateriaId }, materia);
        }

        // PUT: api/materias/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Materia materia)
        {
            if (id != materia.MateriaId) return BadRequest("Id no coincide.");
            _db.Entry(materia).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Materias.AnyAsync(m => m.MateriaId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/materias/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var materia = await _db.Materias.FindAsync(id);
            if (materia == null) return NotFound();

            _db.Materias.Remove(materia);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}