using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    [Authorize(Roles = "Admin,Analyst")]
    public class PmtctCareController : Controller
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PmtctCareController(PmtctContext context ,RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        // GET: PmtctCare
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("Admin");

            if (isAdmin)
            {
                return View(await _context.PmtctCareCascade.ToListAsync());
            }
            else
                return View(await _context.PmtctCareCascade.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync());

            
        }

        // GET: PmtctCare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctCareCascade = await _context.PmtctCareCascade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pmtctCareCascade == null)
            {
                return NotFound();
            }

            return View(pmtctCareCascade);
        }

        // GET: PmtctCare/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            ViewBag.UserId = _userManager.GetUserId(User);
            return View();
        }
        private void PopulateDepartmentsDropDownList(object selectedNumber = null)
        {
            var NambaMshiriki01Query = from d in _context.Pmt
                                       orderby d.NambaMshiriki01
                                       select d;
            ViewBag.NambaMshiriki01 = new SelectList(NambaMshiriki01Query, "NambaMshiriki01", "NambaMshiriki01", selectedNumber);
        }

        // POST: PmtctCare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,SN,ServiceName,ResponseName,ServiceDate,RemarksName,NambaMshiriki01")] PmtctCareCascade pmtctCareCascade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pmtctCareCascade);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Create));
        //    }
        //    return View(pmtctCareCascade);

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserId,SN,ServiceName,ResponseName,ServiceDate,RemarksName,NambaMshiriki01")] PmtctCareCascade pmtctCareCascade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmtctCareCascade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(pmtctCareCascade);

        }

        // GET: PmtctCare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctCareCascade = await _context.PmtctCareCascade.FindAsync(id);
            if (pmtctCareCascade == null)
            {
                return NotFound();
            }
            return View(pmtctCareCascade);
        }

        // POST: PmtctCare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SN,ServiceName,ResponseName,ServiceDate,RemarksName,NambaMshiriki01")] PmtctCareCascade pmtctCareCascade)
        {
            if (id != pmtctCareCascade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmtctCareCascade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PmtctCareCascadeExists(pmtctCareCascade.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pmtctCareCascade);
        }

        // GET: PmtctCare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctCareCascade = await _context.PmtctCareCascade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pmtctCareCascade == null)
            {
                return NotFound();
            }

            return View(pmtctCareCascade);
        }

        // POST: PmtctCare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pmtctCareCascade = await _context.PmtctCareCascade.FindAsync(id);
            _context.PmtctCareCascade.Remove(pmtctCareCascade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PmtctCareCascadeExists(int id)
        {
            return _context.PmtctCareCascade.Any(e => e.ID == id);
        }

       
    }
}
