using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrashanjaController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public PrashanjaController(QuizDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prashanja>>> GetPrashanja()
        {
            var prashanja = await (_context.Prashanja.Select(x => new
            {
                PrashanjeId = x.PrashanjeId,
                Prashanje = x.Prashanje,
                ImeSlika = x.ImeSlika,
                Opcii = new string[] { x.Opcija1, x.Opcija2, x.Opcija3, x.Opcija4 }
            }).OrderBy(y => Guid.NewGuid()).Take(5)).ToListAsync();
            return Ok(prashanja);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prashanja>> GetPrashanja(int id)
        {
          if (_context.Prashanja == null)
          {
              return NotFound();
          }
            var prashanja = await _context.Prashanja.FindAsync(id);

            if (prashanja == null)
            {
                return NotFound();
            }

            return prashanja;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrashanja(int id, Prashanja prashanja)
        {
            if (id != prashanja.PrashanjeId)
            {
                return BadRequest();
            }

            _context.Entry(prashanja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrashanjaExists(id))
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

        [HttpPost]
        [Route("GetOdgovori")]
        public async Task<ActionResult<Prashanja>> VratiPrashanja(int[] pIds)
        {
            var odgovori = await(_context.Prashanja
                .Where(x=> pIds.Contains(x.PrashanjeId))
                .Select(y => new
                {
                    PrashanjeId = y.PrashanjeId,
                    Prashanje = y.Prashanje,
                    ImeSlika = y.ImeSlika,
                    Opcii = new string[] { y.Opcija1, y.Opcija2, y.Opcija3, y.Opcija4 },
                    Odgovor = y.Odgovor
                })).ToListAsync();
            return Ok(odgovori);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrashanja(int id)
        {
            if (_context.Prashanja == null)
            {
                return NotFound();
            }
            var prashanja = await _context.Prashanja.FindAsync(id);
            if (prashanja == null)
            {
                return NotFound();
            }

            _context.Prashanja.Remove(prashanja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrashanjaExists(int id)
        {
            return (_context.Prashanja?.Any(e => e.PrashanjeId == id)).GetValueOrDefault();
        }
    }
}
