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
    [Authorize(Roles = "admin,analyst,dataentry")]
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

            bool isAdmin = User.IsInRole("admin") || User.IsInRole("analyst");

            if (isAdmin)
            {
                return View(await _context.PmtctFollowUp.ToListAsync());
            }
            else
                return View(await _context.PmtctFollowUp.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync());


        }

        // GET: PmtctUp/Details/5
        public async Task<IActionResult> Details(long? id)
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
        private void PopulateDepartmentsDropDownList(object selectedNumber = null)
        {
            var NambaMshiriki01Query = from d in _context.Pmt.Where(uid => uid.UserId == _userManager.GetUserId(User))
                                       orderby d.NambaMshiriki01
                                       select new { d.ID, d.NambaMshiriki01 };
            ViewBag.NambaMshiriki01 = new SelectList(NambaMshiriki01Query, "ID",
                "NambaMshiriki01", selectedNumber);
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
        public async Task<IActionResult> Create([Bind("ID,UserId,TareheHudhurio,HaliYako305a,Mwenza305b1," +
            "Mwanafamiliaa305b2,Wazazi305b3,Rafiki305b1,Mfanyakazi305b5,Wengine305b6,Tajawengine305b7," +
            "Naogopakutengwa306a1,Naogopakuachwa306a2,kunyanyapaliwa306a2,BadosijaaminiVVUliwa306a4," +
            "Sinaninaemwamini306a6,Nyinginezo306a6,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a," +
            "Mwenza308b1,Mwanafamiliaa308b2,Wazazi308b3,Rafiki308b1,Mfanyakazi308b5,Mhudumu308b6,Wengine308b7," +
            "Tajawengine308b8,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,Ushauri310b1,Elimuafya310b2," +
            "Ufuatiliaji310b3,Nyinginezo310b4,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma," +
            "NambaMshiriki01")] PmtctFollowUp pmtctFollowUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmtctFollowUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pmtctFollowUp);
        }

        // GET: PmtctUp/Edit/5
        public async Task<IActionResult> Edit(long? id)
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
        public async Task<IActionResult> Edit(long id, [Bind("ID,UserId,TareheHudhurio,HaliYako305a,Mwenza305b1," +
            "Mwanafamiliaa305b2,Wazazi305b3,Rafiki305b1,Mfanyakazi305b5,Wengine305b6,Tajawengine305b7," +
            "Naogopakutengwa306a1,Naogopakuachwa306a2,kunyanyapaliwa306a2,BadosijaaminiVVUliwa306a4," +
            "Sinaninaemwamini306a6,Nyinginezo306a6,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a," +
            "Mwenza308b1,Mwanafamiliaa308b2,Wazazi308b3,Rafiki308b1,Mfanyakazi308b5,Mhudumu308b6,Wengine308b7," +
            "Tajawengine308b8,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,Ushauri310b1,Elimuafya310b2," +
            "Ufuatiliaji310b3,Nyinginezo310b4,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma," +
            "NambaMshiriki01")] PmtctFollowUp pmtctFollowUp)
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
        public async Task<IActionResult> Delete(long? id)
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
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pmtctFollowUp = await _context.PmtctFollowUp.FindAsync(id);
            _context.PmtctFollowUp.Remove(pmtctFollowUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PmtctFollowUpExists(long id)
        {
            return _context.PmtctFollowUp.Any(e => e.ID == id);
        }
    }
}
