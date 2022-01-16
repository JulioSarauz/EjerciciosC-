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
    public class TPALINDROMOSController : ControllerBase
    {
        private readonly ApiJuioCesarContext _context;

        public TPALINDROMOSController(ApiJuioCesarContext context)
        {
            _context = context;
        }

        // GET: api/TPALINDROMOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPALINDROMOS>>> GetTPALINDROMOS()
        {
            return await _context.TPALINDROMOS.ToListAsync();
        }

        // GET: api/TPALINDROMOS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPALINDROMOS>> GetTPALINDROMOS(int id)
        {
            var tPALINDROMOS = await _context.TPALINDROMOS.FindAsync(id);

            if (tPALINDROMOS == null)
            {
                return NotFound();
            }

            return tPALINDROMOS;
        }

        // PUT: api/TPALINDROMOS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPALINDROMOS(int id, TPALINDROMOS tPALINDROMOS)
        {
            if (id != tPALINDROMOS.id_palindromo)
            {
                return BadRequest();
            }

            _context.Entry(tPALINDROMOS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPALINDROMOSExists(id))
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

        // POST: api/TPALINDROMOS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{palabra}")]
        public async Task<ActionResult<TPALINDROMOS>> PostTPALINDROMOS(string palabra)
        {
            TPALINDROMOS tPALINDROMOS = new TPALINDROMOS();
            _context.TPALINDROMOS.Add(tPALINDROMOS.obtenerInformacion(palabra));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTPALINDROMOS", new { id = tPALINDROMOS.id_palindromo }, tPALINDROMOS);
        }

        // DELETE: api/TPALINDROMOS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TPALINDROMOS>> DeleteTPALINDROMOS(int id)
        {
            var tPALINDROMOS = await _context.TPALINDROMOS.FindAsync(id);
            if (tPALINDROMOS == null)
            {
                return NotFound();
            }

            _context.TPALINDROMOS.Remove(tPALINDROMOS);
            await _context.SaveChangesAsync();

            return tPALINDROMOS;
        }

        private bool TPALINDROMOSExists(int id)
        {
            return _context.TPALINDROMOS.Any(e => e.id_palindromo == id);
        }
    }
}
