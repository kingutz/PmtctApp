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
    [Route("api/PmtctUp")]
    [ApiController]
    public class PmtctFollowApiController : ControllerBase
    {
        private readonly PmtctContext _context;

        public PmtctFollowApiController(PmtctContext context)
        {
            _context = context;
        }

        // GET: api/PmtctFollowApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PmtctFollowUp>>> GetPmtctFollowUp()
        {
            return await _context.PmtctFollowUp.ToListAsync();
        }

        // GET: api/PmtctFollowApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PmtctFollowUp>> GetPmtctFollowUp(int id)
        {
            var pmtctFollowUp = await _context.PmtctFollowUp.FindAsync(id);

            if (pmtctFollowUp == null)
            {
                return NotFound();
            }

            return pmtctFollowUp;
        }

        // PUT: api/PmtctFollowApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPmtctFollowUp(int id, PmtctFollowUp pmtctFollowUp)
        {
            if (id != pmtctFollowUp.ID)
            {
                return BadRequest();
            }

            _context.Entry(pmtctFollowUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PmtctFollowUpExists(id))
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

        // POST: api/PmtctFollowApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PmtctFollowUp>> PostPmtctFollowUp(PmtctFollowUp pmtctFollowUp)
        {
            _context.PmtctFollowUp.Add(pmtctFollowUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPmtctFollowUp", new { id = pmtctFollowUp.ID }, pmtctFollowUp);
        }

        // DELETE: api/PmtctFollowApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PmtctFollowUp>> DeletePmtctFollowUp(int id)
        {
            var pmtctFollowUp = await _context.PmtctFollowUp.FindAsync(id);
            if (pmtctFollowUp == null)
            {
                return NotFound();
            }

            _context.PmtctFollowUp.Remove(pmtctFollowUp);
            await _context.SaveChangesAsync();

            return pmtctFollowUp;
        }

        private bool PmtctFollowUpExists(int id)
        {
            return _context.PmtctFollowUp.Any(e => e.ID == id);
        }
    }
}
