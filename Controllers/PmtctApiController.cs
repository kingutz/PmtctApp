using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Models.PmtctModelView;

namespace Pmtct.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Pmtct")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry")]

    public class PmtctApiController : ControllerBase
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PmtctApiController(PmtctContext context,RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/PmtctApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PmtctData>>> GetPmt()
        {
            //return await _context.Pmt.ToListAsync();
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");

            if (isSuperUser)
            {
                return await _context.Pmt.ToListAsync();
            }
            else
                return await _context.Pmt.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();

           }




        //GET: api/PmtctApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PmtctData>> GetPmtctData(string id)
        {
            var pmtctData = await _context.Pmt.FindAsync(id);
           


            if (pmtctData == null)
            {
                return NotFound();
            }

            return pmtctData;
        }

        // PUT: api/PmtctApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPmtctData(string id, PmtctData pmtctData)
        {
            if (id != pmtctData.NambaMshiriki01)
            {
                return BadRequest();
            }

            _context.Entry(pmtctData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PmtctDataExists(id))
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

        // POST: api/PmtctApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PmtctData>> PostPmtctData(PmtctData pmtctData)
        {
            _context.Pmt.Add(pmtctData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PmtctDataExists(pmtctData.NambaMshiriki01))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPmtctData", new { id = pmtctData.NambaMshiriki01 }, pmtctData);
        }

        // DELETE: api/PmtctApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PmtctData>> DeletePmtctData(string id)
        {
            var pmtctData = await _context.Pmt.FindAsync(id);
            if (pmtctData == null)
            {
                return NotFound();
            }

            _context.Pmt.Remove(pmtctData);
            await _context.SaveChangesAsync();

            return pmtctData;
        }

        private bool PmtctDataExists(string id)
        {
            return _context.Pmt.Any(e => e.NambaMshiriki01 == id);
        }
    }
}
