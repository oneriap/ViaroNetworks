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
    public class ProfesorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesors()
        {
          if (_context.Profesors == null)
          {
              return NotFound();
          }
            return await _context.Profesors.ToListAsync();
        }

        // GET: api/Profesor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
          if (_context.Profesors == null)
          {
              return NotFound();
          }
            var profesor = await _context.Profesors.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/Profesor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor profesor)
        {
          if (_context.Profesors == null)
          {
              return Problem("Entity set 'AppDbContext.Profesors'  is null.");
          }
            _context.Profesors.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesor", new { id = profesor.Id }, profesor);
        }

        // DELETE: api/Profesor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            if (_context.Profesors == null)
            {
                return NotFound();
            }
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesors.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesorExists(int id)
        {
            return (_context.Profesors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
