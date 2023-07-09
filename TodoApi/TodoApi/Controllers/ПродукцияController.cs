using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ПродукцияController : ControllerBase
    {
        private readonly РельсыContext _context;

        public ПродукцияController(РельсыContext context)
        {
            _context = context;
        }

        // GET: api/Продукция
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Продукция>>> GetПродукцияs()
        {
          if (_context.Продукцияs == null)
          {
              return NotFound();
          }
            return await _context.Продукцияs.ToListAsync();
        }

        // GET: api/Продукция/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Продукция>> GetПродукция(Guid id)
        {
          if (_context.Продукцияs == null)
          {
              return NotFound();
          }
            var продукция = await _context.Продукцияs.FindAsync(id);

            if (продукция == null)
            {
                return NotFound();
            }

            return продукция;
        }

        // PUT: api/Продукция/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutПродукция(Guid id, Продукция продукция)
        {
            if (id != продукция.Id)
            {
                return BadRequest();
            }

            _context.Entry(продукция).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ПродукцияExists(id))
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

        // POST: api/Продукция
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Продукция>> PostПродукция(Продукция продукция)
        {
          if (_context.Продукцияs == null)
          {
              return Problem("Entity set 'РельсыContext.Продукцияs'  is null.");
          }
            _context.Продукцияs.Add(продукция);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ПродукцияExists(продукция.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetПродукция", new { id = продукция.Id }, продукция);
        }

        // DELETE: api/Продукция/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteПродукция(Guid id)
        {
            if (_context.Продукцияs == null)
            {
                return NotFound();
            }
            var продукция = await _context.Продукцияs.FindAsync(id);
            if (продукция == null)
            {
                return NotFound();
            }

            _context.Продукцияs.Remove(продукция);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ПродукцияExists(Guid id)
        {
            return (_context.Продукцияs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
