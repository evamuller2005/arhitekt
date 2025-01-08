using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arhitekt.Data;
using Arhitekt.Models;

namespace Arhitekt.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchitechtApiController : ControllerBase
    {
        private readonly ArhitektContext _context;

        public ArchitechtApiController(ArhitektContext context)
        {
            _context = context;
        }

        // GET: api/ArchitechtApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Architect>>> GetArchitects()
        {
            return await _context.Architects.ToListAsync();
        }

        // GET: api/ArchitechtApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Architect>> GetArchitect(int id)
        {
            var architect = await _context.Architects.FindAsync(id);

            if (architect == null)
            {
                return NotFound();
            }

            return architect;
        }

        // PUT: api/ArchitechtApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchitect(int id, Architect architect)
        {
            if (id != architect.ArchitectID)
            {
                return BadRequest();
            }

            _context.Entry(architect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchitectExists(id))
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

        // POST: api/ArchitechtApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Architect>> PostArchitect(Architect architect)
        {
            _context.Architects.Add(architect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchitect", new { id = architect.ArchitectID }, architect);
        }

        // DELETE: api/ArchitechtApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchitect(int id)
        {
            var architect = await _context.Architects.FindAsync(id);
            if (architect == null)
            {
                return NotFound();
            }

            _context.Architects.Remove(architect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchitectExists(int id)
        {
            return _context.Architects.Any(e => e.ArchitectID == id);
        }
    }
}
