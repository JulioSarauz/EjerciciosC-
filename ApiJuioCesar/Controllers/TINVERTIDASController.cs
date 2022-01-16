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
    public class TINVERTIDASController : ControllerBase
    {
        private readonly ApiJuioCesarContext _context;

        public TINVERTIDASController(ApiJuioCesarContext context)
        {
            _context = context;
        }

        // GET: api/TINVERTIDAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TINVERTIDAS>>> GetTINVERTIDAS()
        {
            return await _context.TINVERTIDAS.ToListAsync();
        }

        // GET: api/TINVERTIDAS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TINVERTIDAS>> GetTINVERTIDAS(int id)
        {
            var tINVERTIDAS = await _context.TINVERTIDAS.FindAsync(id);

            if (tINVERTIDAS == null)
            {
                return NotFound();
            }

            return tINVERTIDAS;
        }

        // PUT: api/TINVERTIDAS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTINVERTIDAS(int id, TINVERTIDAS tINVERTIDAS)
        {
            if (id != tINVERTIDAS.id_invertida)
            {
                return BadRequest();
            }

            _context.Entry(tINVERTIDAS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TINVERTIDASExists(id))
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

        // POST: api/TINVERTIDAS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{cadena}")]
        public async Task<ActionResult<TINVERTIDAS>> PostTINVERTIDAS(string cadena)
        {
            TINVERTIDAS tINVERTIDAS = new TINVERTIDAS();
            _context.TINVERTIDAS.Add(tINVERTIDAS.obtenerInformacion(cadena));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTINVERTIDAS", new { id = tINVERTIDAS.id_invertida }, tINVERTIDAS);
        }

        // DELETE: api/TINVERTIDAS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TINVERTIDAS>> DeleteTINVERTIDAS(int id)
        {
            var tINVERTIDAS = await _context.TINVERTIDAS.FindAsync(id);
            if (tINVERTIDAS == null)
            {
                return NotFound();
            }

            _context.TINVERTIDAS.Remove(tINVERTIDAS);
            await _context.SaveChangesAsync();

            return tINVERTIDAS;
        }

        private bool TINVERTIDASExists(int id)
        {
            return _context.TINVERTIDAS.Any(e => e.id_invertida == id);
        }
    }
}
