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

namespace Pmtct.Controllers
{
    [Authorize(Roles = "admin,analyst,dataentry,dataclerk")]
    public class PmtctUpController : Controller
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PmtctUpController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: PmtctUp
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("admin");

            if (isAdmin)
            {
                return View(await _context.PmtctFollowUp.ToListAsync());
            }
            else
                return View(await _context.PmtctFollowUp.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync());



            
        }
        private void PopulateDepartmentsDropDownList(object selectedNumber = null)
        {
            var NambaMshiriki01Query = from d in _context.Pmt
                                       orderby d.NambaMshiriki01
                                       select d;
            ViewBag.NambaMshiriki01 = new SelectList(NambaMshiriki01Query, "NambaMshiriki01", "NambaMshiriki01", selectedNumber);
        }

        // GET: PmtctUp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole("admin");
            var pmtctAdmin = await _context.PmtctFollowUp.FirstOrDefaultAsync(m => m.ID == id);

            if (isAdmin)
            {
                return View(pmtctAdmin);
            }
            else
            {
                var pmtctUser = await _context.PmtctFollowUp.FirstOrDefaultAsync(m => m.ID == id && m.UserId == _userManager.GetUserId(User));
                return View(pmtctUser);
            }
            
        }

        // GET: PmtctUp/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            ViewBag.UserId = _userManager.GetUserId(User);
            return View();
        }

        // POST: PmtctUp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Namba01,UserId,TareheHudhurio,HaliYako305a,KamaHapana305a,KamaNdio305b,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a,NaniKutendea308b,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,HudumaHulipatiwa310b,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma,NambaMshiriki01")] PmtctFollowUp pmtctFollowUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmtctFollowUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(pmtctFollowUp);
        }

        // GET: PmtctUp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctFollowUp = await _context.PmtctFollowUp.FindAsync(id);
            if (pmtctFollowUp == null)
            {
                return NotFound();
            }
            return View(pmtctFollowUp);
        }

        // POST: PmtctUp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Namba01,UserId,TareheHudhurio,HaliYako305a,KamaHapana305a,KamaNdio305b,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a,NaniKutendea308b,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,HudumaHulipatiwa310b,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma,NambaMshiriki01")] PmtctFollowUp pmtctFollowUp)
        {
            if (id != pmtctFollowUp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmtctFollowUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PmtctFollowUpExists(pmtctFollowUp.ID))
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
            return View(pmtctFollowUp);
        }

        // GET: PmtctUp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctFollowUp = await _context.PmtctFollowUp
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pmtctFollowUp == null)
            {
                return NotFound();
            }

            return View(pmtctFollowUp);
        }

        // POST: PmtctUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pmtctFollowUp = await _context.PmtctFollowUp.FindAsync(id);
            _context.PmtctFollowUp.Remove(pmtctFollowUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PmtctFollowUpExists(int id)
        {
            return _context.PmtctFollowUp.Any(e => e.ID == id);
        }
    }
}
