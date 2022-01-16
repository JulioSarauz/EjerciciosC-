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
    public class TNUMEROSMAYORESController : ControllerBase
    {
        private readonly ApiJuioCesarContext _context;

        public TNUMEROSMAYORESController(ApiJuioCesarContext context)
        {
            _context = context;
        }

        // GET: api/TNUMEROSMAYORES
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNUMEROSMAYORES>>> GetTNUMEROSMAYORES()
        {
            return await _context.TNUMEROSMAYORES.ToListAsync();
        }

        // GET: api/TNUMEROSMAYORES/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNUMEROSMAYORES>> GetTNUMEROSMAYORES(int id)
        {
            var tNUMEROSMAYORES = await _context.TNUMEROSMAYORES.FindAsync(id);

            if (tNUMEROSMAYORES == null)
            {
                return NotFound();
            }

            return tNUMEROSMAYORES;
        }

        // PUT: api/TNUMEROSMAYORES/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNUMEROSMAYORES(int id, TNUMEROSMAYORES tNUMEROSMAYORES)
        {
            if (id != tNUMEROSMAYORES.id_numeromayor)
            {
                return BadRequest();
            }

            _context.Entry(tNUMEROSMAYORES).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNUMEROSMAYORESExists(id))
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

        // POST: api/TNUMEROSMAYORES
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{numeros}")]
        public async Task<ActionResult<TNUMEROSMAYORES>> PostTNUMEROSMAYORES(string numeros)
        {
            TNUMEROSMAYORES tNUMEROSMAYORES = new TNUMEROSMAYORES();
            _context.TNUMEROSMAYORES.Add(tNUMEROSMAYORES.obtenerInformacion(numeros));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNUMEROSMAYORES", new { id = tNUMEROSMAYORES.id_numeromayor }, tNUMEROSMAYORES);
        }

        // DELETE: api/TNUMEROSMAYORES/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNUMEROSMAYORES>> DeleteTNUMEROSMAYORES(int id)
        {
            var tNUMEROSMAYORES = await _context.TNUMEROSMAYORES.FindAsync(id);
            if (tNUMEROSMAYORES == null)
            {
                return NotFound();
            }

            _context.TNUMEROSMAYORES.Remove(tNUMEROSMAYORES);
            await _context.SaveChangesAsync();

            return tNUMEROSMAYORES;
        }

        private bool TNUMEROSMAYORESExists(int id)
        {
            return _context.TNUMEROSMAYORES.Any(e => e.id_numeromayor == id);
        }
    }
}
