using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiJuioCesar.Data;
using ApiJuioCesar.Modelo;

namespace ApiJuioCesar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPALABRASREPETIDASController : ControllerBase
    {
        private readonly ApiJuioCesarContext _context;

        public TPALABRASREPETIDASController(ApiJuioCesarContext context)
        {
            _context = context;
        }

        // GET: api/TPALABRASREPETIDAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPALABRASREPETIDAS>>> GetTPALABRASREPETIDAS()
        {
            return await _context.TPALABRASREPETIDAS.ToListAsync();
        }

        // GET: api/TPALABRASREPETIDAS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPALABRASREPETIDAS>> GetTPALABRASREPETIDAS(int id)
        {
            var tPALABRASREPETIDAS = await _context.TPALABRASREPETIDAS.FindAsync(id);

            if (tPALABRASREPETIDAS == null)
            {
                return NotFound();
            }

            return tPALABRASREPETIDAS;
        }

        // PUT: api/TPALABRASREPETIDAS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPALABRASREPETIDAS(int id, TPALABRASREPETIDAS tPALABRASREPETIDAS)
        {
            if (id != tPALABRASREPETIDAS.id_palabra)
            {
                return BadRequest();
            }

            _context.Entry(tPALABRASREPETIDAS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPALABRASREPETIDASExists(id))
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

        // POST: api/TPALABRASREPETIDAS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{cadena}/{palabra}")]
        public async Task<ActionResult> PostTPALABRASREPETIDAS(string cadena,string palabra)
        {
            
            TPALABRASREPETIDAS tPALABRASREPETIDAS = new TPALABRASREPETIDAS();
            _context.TPALABRASREPETIDAS.Add(tPALABRASREPETIDAS.obtenerInformacion(cadena,palabra));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPALABRASREPETIDAS", new { id = tPALABRASREPETIDAS.id_palabra }, tPALABRASREPETIDAS);
        }

        // DELETE: api/TPALABRASREPETIDAS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TPALABRASREPETIDAS>> DeleteTPALABRASREPETIDAS(int id)
        {
            var tPALABRASREPETIDAS = await _context.TPALABRASREPETIDAS.FindAsync(id);
            if (tPALABRASREPETIDAS == null)
            {
                return NotFound();
            }

            _context.TPALABRASREPETIDAS.Remove(tPALABRASREPETIDAS);
            await _context.SaveChangesAsync();

            return tPALABRASREPETIDAS;
        }

        private bool TPALABRASREPETIDASExists(int id)
        {
            return _context.TPALABRASREPETIDAS.Any(e => e.id_palabra == id);
        }
    }
}
