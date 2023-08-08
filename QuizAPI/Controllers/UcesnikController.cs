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
    public class UcesnikController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public UcesnikController(QuizDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ucesnik>>> GetUcesnici()
        {
          if (_context.Ucesnici == null)
          {
              return NotFound();
          }
            return await _context.Ucesnici.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ucesnik>> GetUcesnik(int id)
        {
          if (_context.Ucesnici == null)
          {
              return NotFound();
          }
            var ucesnik = await _context.Ucesnici.FindAsync(id);

            if (ucesnik == null)
            {
                return NotFound();
            }

            return ucesnik;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUcesnik(int id, UcesnikRezultat _ucesnikRezultat)
        {
            if (id != _ucesnikRezultat.UcesnikId)
            {
                return BadRequest();
            }
            Ucesnik ucesnik = _context.Ucesnici.Find(id);
            ucesnik.Poeni = _ucesnikRezultat.Poeni;
            ucesnik.Vreme = _ucesnikRezultat.Vreme;

            _context.Entry(ucesnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UcesnikExists(id))
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
        public async Task<ActionResult<Ucesnik>> PostUcesnik(Ucesnik ucesnik)
        {
            var proverka = _context.Ucesnici.Where(p => p.Ime == ucesnik.Ime && p.Prezime == ucesnik.Prezime && p.Email == ucesnik.Email).FirstOrDefault();
            if (proverka == null)
            {
                _context.Ucesnici.Add(ucesnik);
                await _context.SaveChangesAsync();
            }
            else
                ucesnik = proverka;
            return Ok(ucesnik);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUcesnik(int id)
        {
            if (_context.Ucesnici == null)
            {
                return NotFound();
            }
            var ucesnik = await _context.Ucesnici.FindAsync(id);
            if (ucesnik == null)
            {
                return NotFound();
            }

            _context.Ucesnici.Remove(ucesnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UcesnikExists(int id)
        {
            return (_context.Ucesnici?.Any(e => e.UcesnikId == id)).GetValueOrDefault();
        }
    }
}
