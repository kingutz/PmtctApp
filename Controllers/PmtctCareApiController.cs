using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;

namespace Pmtct.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/PmtctCare")]
    [ApiController]
    public class PmtctCareApiController : ControllerBase
    {
        private readonly PmtctContext _context;

        public PmtctCareApiController(PmtctContext context)
        {
            _context = context;
        }

        // GET: api/PmtctCareApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PmtctCareCascade>>> GetPmtctCareCascade()
        {
            return await _context.PmtctCareCascade.ToListAsync();
        }

        // GET: api/PmtctCareApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PmtctCareCascade>> GetPmtctCareCascade(int id)
        {
            var pmtctCareCascade = await _context.PmtctCareCascade.FindAsync(id);

            if (pmtctCareCascade == null)
            {
                return NotFound();
            }

            return pmtctCareCascade;
        }

        // PUT: api/PmtctCareApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPmtctCareCascade(int id, PmtctCareCascade pmtctCareCascade)
        {
            if (id != pmtctCareCascade.ID)
            {
                return BadRequest();
            }

            _context.Entry(pmtctCareCascade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PmtctCareCascadeExists(id))
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

        // POST: api/PmtctCareApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PmtctCareCascade>> PostPmtctCareCascade(PmtctCareCascade pmtctCareCascade)
        {
            _context.PmtctCareCascade.Add(pmtctCareCascade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPmtctCareCascade", new { id = pmtctCareCascade.ID }, pmtctCareCascade);
        }

        // DELETE: api/PmtctCareApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PmtctCareCascade>> DeletePmtctCareCascade(int id)
        {
            var pmtctCareCascade = await _context.PmtctCareCascade.FindAsync(id);
            if (pmtctCareCascade == null)
            {
                return NotFound();
            }

            _context.PmtctCareCascade.Remove(pmtctCareCascade);
            await _context.SaveChangesAsync();

            return pmtctCareCascade;
        }

        private bool PmtctCareCascadeExists(int id)
        {
            return _context.PmtctCareCascade.Any(e => e.ID == id);
        }

        
    }
}
