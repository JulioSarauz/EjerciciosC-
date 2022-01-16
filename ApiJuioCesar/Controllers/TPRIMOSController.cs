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
    public class TPRIMOSController : ControllerBase
    {
        private readonly ApiJuioCesarContext _context;

        public TPRIMOSController(ApiJuioCesarContext context)
        {
            _context = context;
        }

        // GET: api/TPRIMOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TPRIMOS>>> GetTPRIMOS()
        {
            return await _context.TPRIMOS.ToListAsync();
        }

        // GET: api/TPRIMOS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TPRIMOS>> GetTPRIMOS(int id)
        {
            var tPRIMOS = await _context.TPRIMOS.FindAsync(id);

            if (tPRIMOS == null)
            {
                return NotFound();
            }

            return tPRIMOS;
        }

        // PUT: api/TPRIMOS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTPRIMOS(int id, TPRIMOS tPRIMOS)
        {
            if (id != tPRIMOS.id_primo)
            {
                return BadRequest();
            }

            _context.Entry(tPRIMOS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPRIMOSExists(id))
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

        // POST: api/TPRIMOS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{numero}")]
        //public async Task<ActionResult<TPRIMOS>> PostTPRIMOS(TPRIMOS tPRIMOS)
        //{
        //    _context.TPRIMOS.Add(tPRIMOS);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetTPRIMOS", new { id = tPRIMOS.id_primo }, tPRIMOS);
        //}

        public async Task<ActionResult<TPRIMOS>> PostTPRIMOS(int numero)
        {
            TPRIMOS tPRIMOS = new TPRIMOS();
            _context.TPRIMOS.Add(tPRIMOS.obtenerInformacion(numero));
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTPRIMOS", new { id = tPRIMOS.id_primo }, tPRIMOS);
        }





        // DELETE: api/TPRIMOS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TPRIMOS>> DeleteTPRIMOS(int id)
        {
            var tPRIMOS = await _context.TPRIMOS.FindAsync(id);
            if (tPRIMOS == null)
            {
                return NotFound();
            }

            _context.TPRIMOS.Remove(tPRIMOS);
            await _context.SaveChangesAsync();

            return tPRIMOS;
        }

        private bool TPRIMOSExists(int id)
        {
            return _context.TPRIMOS.Any(e => e.id_primo == id);
        }
    }
}
