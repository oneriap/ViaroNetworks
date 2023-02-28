using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViaroTest.Data;
using ViaroTest.Models;

namespace ViaroTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoGradoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlumnoGradoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AlumnoGrado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnoGrado>>> GetAlumnoGrados()
        {
          if (_context.AlumnoGrados == null)
          {
              return NotFound();
          }
            return await _context.AlumnoGrados.ToListAsync();
        }

        // GET: api/AlumnoGrado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoGrado>> GetAlumnoGrado(int id)
        {
          if (_context.AlumnoGrados == null)
          {
              return NotFound();
          }
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);

            if (alumnoGrado == null)
            {
                return NotFound();
            }

            return alumnoGrado;
        }

        // PUT: api/AlumnoGrado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnoGrado(int id, AlumnoGrado alumnoGrado)
        {
            if (id != alumnoGrado.Id)
            {
                return BadRequest();
            }

            _context.Entry(alumnoGrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoGradoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AlumnoGrado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlumnoGrado>> PostAlumnoGrado(AlumnoGrado alumnoGrado)
        {
          if (_context.AlumnoGrados == null)
          {
              return Problem("Entity set 'AppDbContext.AlumnoGrados'  is null.");
          }
            _context.AlumnoGrados.Add(alumnoGrado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnoGrado", new { id = alumnoGrado.Id }, alumnoGrado);
        }

        // DELETE: api/AlumnoGrado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnoGrado(int id)
        {
            if (_context.AlumnoGrados == null)
            {
                return NotFound();
            }
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }

            _context.AlumnoGrados.Remove(alumnoGrado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnoGradoExists(int id)
        {
            return (_context.AlumnoGrados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
